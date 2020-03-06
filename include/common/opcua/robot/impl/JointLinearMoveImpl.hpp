//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_ROBOT_SKILLS_JOINTLINEARMOVEIMPL_HPP
#define ROBOTICS_ROBOT_SKILLS_JOINTLINEARMOVEIMPL_HPP

#include "common/opcua/skill/robot/JointLinearMoveSkill.hpp"
#include "RLSkillImpl.hpp"

#include "common/opcua/robot/LinearInterpolator.hpp"

namespace fortiss {
    namespace opcua {
        namespace robot {

            template<int AXIS_COUNT>
            class JointLinearMoveImpl : virtual public fortiss::opcua::skill::robot::JointLinearMoveSkillImpl<AXIS_COUNT>,
                                        virtual public RLSkillImpl {

            private:
                rl::math::Vector targetJointPosition;
                std::function<void(const rl::math::Vector &)> setJointPosition;
                ::std::chrono::nanoseconds updateRate;
                LinearInterpolator *interpolator = nullptr;
                bool active = false;

                std::chrono::steady_clock::time_point skillStartTime;
                size_t stepsExecuted = 0;

                // The interpolator is deleted during the halt method so make sure it cannot be called
                // at the same time as step
                std::mutex stepMutex;

            public:
                explicit JointLinearMoveImpl(const std::shared_ptr<spdlog::logger> &logger,
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

                virtual ~JointLinearMoveImpl() {
                    if (interpolator)
                        delete interpolator;
                }

            protected:

                bool start(const std::array<double, AXIS_COUNT> &targetJointPositionArr,
                           const std::string &toolFrame,
                           const std::array<double, 6> &maxVelocity,
                           const std::array<double, 6> &maxAcceleration) override {

                    if (interpolator != nullptr) {
                        logger->error("Interpolator is already initialized. This can not be...");
                        return false;
                    }

                    targetJointPosition = rl::math::Vector::Zero(AXIS_COUNT);
                    for (unsigned int i = 0; i < AXIS_COUNT; i++)
                        targetJointPosition[i] = targetJointPositionArr[i];

                    std::stringstream ss;
                    ss << "Moving (Joint Linear): ";
                    for (unsigned int i = 0; i < AXIS_COUNT; i++) {
                        ss << " ";
                        ss << targetJointPosition[i] * RAD_TO_DEG;
                    }
                    logger->info(ss.str());

                    ::rl::math::Vector3 maxPositionVelocity = ::rl::math::Vector3::Ones();
                    ::rl::math::Vector3 maxPositionAcceleration = ::rl::math::Vector3::Ones();
                    ::rl::math::Vector3 maxOrientationVelocity = ::rl::math::Vector3::Constant(
                            100 * rl::math::DEG2RAD);
                    ::rl::math::Vector3 maxOrientationAcceleration = ::rl::math::Vector3::Constant(
                            100 * rl::math::DEG2RAD);

                    if (*std::max_element(maxVelocity.begin(), maxVelocity.end()) > 0) {
                        for (size_t i = 0; i < 3; i++) {
                            maxPositionVelocity[i] = maxVelocity[i];
                            maxOrientationVelocity[i] = maxVelocity[i + 3];
                        }
                    }
                    if (*std::max_element(maxAcceleration.begin(), maxAcceleration.end()) > 0) {
                        for (size_t i = 0; i < 3; i++) {
                            maxPositionAcceleration[i] = maxAcceleration[i];
                            maxOrientationAcceleration[i] = maxAcceleration[i + 3];
                        }
                    }


                    kinematic->setPosition(targetJointPosition);
                    kinematic->forwardPosition();
                    ::rl::math::Transform targetCartesianPosition = this->kinematic->getOperationalPosition(0);

                    rl::math::Vector q0 = getJointPosition();

                    kinematic->setPosition(q0);
                    kinematic->forwardPosition();
                    ::rl::math::Transform x0 = this->kinematic->getOperationalPosition(0);


                    interpolator = new LinearInterpolator(kinematic, q0, x0, targetJointPosition,
                                                          targetCartesianPosition, maxPositionVelocity,
                                                          maxPositionAcceleration,
                                                          maxOrientationVelocity, maxOrientationAcceleration);

                    if (!interpolator->isValid(updateRate)) {
                        logger->error("Failed calculating linear interpolation");
                        delete interpolator;
                        interpolator = nullptr;
                        return false;
                    }

                    skillStartTime = std::chrono::steady_clock::now();
                    stepsExecuted = 0;
                    active = true;

                    return true;
                }

                bool halt() override {
                    stepMutex.lock();
                    active = false;
                    delete interpolator;
                    interpolator = nullptr;
                    stepMutex.unlock();
                    return true;
                }

                bool resume() override {
                    return false;

                }

                bool suspend() override {
                    return false;

                }

                bool reset() override {
                    return false;

                }

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
                    ::rl::math::Transform x0 = kinematicRunner->getOperationalPosition(0);

                    ::rl::math::Vector qt;
                    ::rl::math::Vector qdt;
                    ::rl::math::Transform xt;

                    bool success = interpolator->getInterpolatedJointPosition(kinematicRunner, q0, x0, ti, &qt, &qdt, &xt);

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


#endif //ROBOTICS_ROBOT_SKILLS_JOINTLINEARMOVEIMPL_HPP
