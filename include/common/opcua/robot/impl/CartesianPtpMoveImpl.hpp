//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_ROBOT_SKILLS_CARTESIANPTPMOVEIMPL_HPP
#define ROBOTICS_ROBOT_SKILLS_CARTESIANPTPMOVEIMPL_HPP

#include "common/opcua/skill/robot/CartesianPtpMoveSkill.hpp"
#include "RLSkillImpl.hpp"

namespace fortiss {
    namespace opcua {
        namespace robot {

            template<int AXIS_COUNT>
            class CartesianPtpMoveImpl : virtual public fortiss::opcua::skill::robot::CartesianPtpMoveSkillImpl<AXIS_COUNT>,
                                         virtual public RLSkillImpl {

            private:


                rl::math::Transform targetCartesianPosition;
                std::function<void(const rl::math::Vector &)> setJointPosition;
                ::std::chrono::nanoseconds updateRate;
                PtpInterpolator *interpolator = nullptr;
                bool active = false;

                std::chrono::steady_clock::time_point skillStartTime;
                size_t stepsExecuted = 0;

                // The interpolator is deleted during the halt method so make sure it cannot be called
                // at the same time as step
                std::mutex stepMutex;

            public:
                explicit CartesianPtpMoveImpl(const std::shared_ptr<spdlog::logger> &logger,
                                              const std::function<const rl::math::Vector()>& getJointPosition,
                                              const std::function<void(const rl::math::Vector& pos)>& setJointPosition,
                                              ::std::chrono::nanoseconds updateRate,
                                              const std::shared_ptr<rl::mdl::Dynamic> &kinematic) :
                        RLSkillImpl(logger, getJointPosition, kinematic),
                        setJointPosition(setJointPosition),
                        updateRate(updateRate),
                        interpolator(),
                        skillStartTime() {
                    if (kinematic->getDof() != AXIS_COUNT)
                        throw std::runtime_error("AXIS_COUNT does not match DOF");

                }

                virtual ~CartesianPtpMoveImpl() {
                    if (interpolator)
                        delete interpolator;
                }

            protected:
                bool start(const UA_ThreeDFrame &targetPosition,
                           const std::string &toolFrame,
                           const std::array<double, AXIS_COUNT> &maxVelocity,
                           const std::array<double, AXIS_COUNT> &maxAcceleration,
                           const std::array<UA_Range, AXIS_COUNT> &axisBounds) override {

                    if (interpolator != nullptr) {
                        logger->error("Interpolator is already initialized. This can not be...");
                        return false;
                    }

                    logger->info("Moving (Cartesian PTP): {}, {}, {}, {}, {}, {}",
                                 targetPosition.cartesianCoordinates.x, targetPosition.cartesianCoordinates.y,
                                 targetPosition.cartesianCoordinates.z,
                                 targetPosition.orientation.a * RAD_TO_DEG, targetPosition.orientation.b * RAD_TO_DEG,
                                 targetPosition.orientation.c * RAD_TO_DEG);

                    targetCartesianPosition = ::rl::math::AngleAxis(
                            targetPosition.orientation.c,
                            ::rl::math::Vector3::UnitZ()
                    ) * ::rl::math::AngleAxis(
                            targetPosition.orientation.b,
                            ::rl::math::Vector3::UnitY()
                    ) * ::rl::math::AngleAxis(
                            targetPosition.orientation.a,
                            ::rl::math::Vector3::UnitX()
                    );
                    targetCartesianPosition.translation().x() = targetPosition.cartesianCoordinates.x;
                    targetCartesianPosition.translation().y() = targetPosition.cartesianCoordinates.y;
                    targetCartesianPosition.translation().z() = targetPosition.cartesianCoordinates.z;

                    rl::math::Vector targetJointPosition;

                    ::rl::math::Vector lowerBounds;
                    ::rl::math::Vector upperBounds;
                    bool isNull = true;
                    for (size_t i = 0; i < AXIS_COUNT && isNull; i++) {
                        isNull = axisBounds[i].low == 0 && axisBounds[i].high == 0;
                    }

                    if (!isNull) {
                        lowerBounds = rl::math::Vector(AXIS_COUNT);
                        upperBounds = rl::math::Vector(AXIS_COUNT);
                        for (size_t i = 0; i < AXIS_COUNT; i++) {
                            lowerBounds[i] = axisBounds[i].low;
                            upperBounds[i] = axisBounds[i].high;
                        }
                    } else {
                        lowerBounds = rl::math::Vector();
                        upperBounds = rl::math::Vector();
                    }


                    rl::math::Vector q0 = getJointPosition();
                    kinematic->setPosition(q0);
                    kinematic->forwardPosition();
                    if (!getInverseKinematics(targetCartesianPosition, targetJointPosition, lowerBounds, upperBounds)) {
                        logger->error(
                                "Could not calculate inverse kinematics. Position can probably not be reached.");
                        return false;
                    }


                    std::stringstream ss;
                    for (unsigned int i = 0; i < AXIS_COUNT; i++) {
                        ss << " ";
                        ss << targetJointPosition[i] * RAD_TO_DEG;
                    }

                    logger->info("Moving (Cartesian as Joint Target): {}", ss.str());


                    rl::math::Vector maxVelo = this->kinematic->getSpeed();
                    rl::math::Vector maxAccel = rl::math::Vector::Constant(kinematic->getDofPosition(),
                                                                           100 * rl::math::DEG2RAD);

                    if (*std::max_element(maxVelocity.begin(), maxVelocity.end()) > 0) {
                        for (size_t i = 0; i < AXIS_COUNT; i++) {
                            maxVelo[i] = maxVelocity[i];
                        }
                    }
                    if (*std::max_element(maxAcceleration.begin(), maxAcceleration.end()) > 0) {
                        for (size_t i = 0; i < AXIS_COUNT; i++) {
                            maxAccel[i] = maxAcceleration[i];
                        }
                    }

                    interpolator = new PtpInterpolator(kinematic, q0,
                                                       targetJointPosition, maxVelo, maxAccel);

                    if (!interpolator->isValid(updateRate)) {
                        logger->error("Failed calculating joint interpolation");
                        delete interpolator;
                        return false;
                    }

                    skillStartTime = std::chrono::steady_clock::now();
                    stepsExecuted = 0;
                    active = true;
                    return true;
                };

                bool halt() override {
                    stepMutex.lock();
                    active = false;
                    delete interpolator;
                    interpolator = nullptr;
                    stepMutex.unlock();
                    return true;
                };

                bool resume() override {
                    return false;

                };

                bool suspend() override {
                    return false;

                };

                bool reset() override {
                    return false;

                };

                void step(rl::mdl::Dynamic *kinematicRunner) override {
                    stepMutex.lock();

                    // The interpolator could be null if the mutex was just released
                    if (!interpolator) {
                        stepMutex.unlock();
                        return;
                    }

                    auto timeSteps = interpolator->getTimeStep(updateRate);

                    if (stepsExecuted >= timeSteps.second) {
                        active = false;
                        this->moveFinished();
                        logger->info("Move finished");
                        delete interpolator;
                        interpolator = nullptr;
                        stepMutex.unlock();
                        return;
                    }

                    //std::chrono::steady_clock::time_point currentTime = std::chrono::steady_clock::now();
                    ::rl::math::Real ti = ((double)++stepsExecuted) * timeSteps.first;

                    ::rl::math::Vector q0 = getJointPosition();
                    kinematicRunner->setPosition(q0);
                    kinematicRunner->forwardPosition();

                    ::rl::math::Vector qt;
                    ::rl::math::Vector qdt;

                    bool success = interpolator->getInterpolatedJointPosition(kinematicRunner, q0, ti, updateRate, &qt, &qdt);

                    if (!success) {
                        active = false;
                        std::stringstream ss;
                        ss << qt.transpose() * rl::math::RAD2DEG;
                        logger->error("Can not calculate next interpolation. Joint limits exceeded: {}", ss.str());
                        delete interpolator;
                        this->moveErrored();
                        stepMutex.unlock();
                        return;
                    }
                    setJointPosition(qt);
                    stepMutex.unlock();
                }

                bool isActive() override {
                    return active;
                }
            };
        }
    }
}


#endif //ROBOTICS_ROBOT_SKILLS_CARTESIANPTPMOVEIMPL_HPP
