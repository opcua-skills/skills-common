/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_RLSKILLIMPL_HPP
#define ROBOTICS_RLSKILLIMPL_HPP

#include "common/opcua/skill/SkillRunMutex.hpp"
#include <rl/mdl/Dynamic.h>

#ifdef RL_MDL_NLOPT

#include <rl/mdl/NloptInverseKinematics.h>
#include <rl/hal/CartesianPositionSensor.h>

#else
#include <rl/mdl/JacobianInverseKinematics.h>
#endif

namespace fortiss {
    namespace opcua {
        namespace robot {
        class RLSkillImpl : public virtual fortiss::opcua::skill::SkillImpl {

            private:


                /* If all the joint angles differentiate less than this value, the target position is seen as reached (in joint move).
                 * Value is in RAD */
                const double jointDelta = 0.00872665; // 0.5 Degree

                /* If the robot cartesian position deviates less than this value (in meters/rad), the target position is seen as reached (in cartesian move).
                 * Value is in meters */
                const double cartesianDeltaTranslation = 0.0003;
                /* Value is in rad */
                const double cartesianDeltaRotation = 0.008;

            protected:
                std::shared_ptr<spdlog::logger> logger;
                std::shared_ptr<rl::mdl::Dynamic> kinematic;
                std::function<const rl::math::Vector()> getJointPosition;
                
                bool targetAlreadyReached = false;

                bool getInverseKinematics(const rl::math::Transform &x, rl::math::Vector &joints,
                                          const rl::math::Vector &lowerBounds = rl::math::Vector(),
                                          const rl::math::Vector &upperBounds = rl::math::Vector()) {
                    rl::math::Transform x_robot;

                    /*if (data.toolPresent) {
                //        std::cout << "compensating tool offset" << std::endl;
                        x_robot = x * data.toolOffset.inverse();
                    }
                    else {*/
                    x_robot = x;
                    //}

                    //if (verbose) {
                    /*
                    std::cout << "after compensation " << std::endl;
                    std::cout << x_robot.matrix() << std::endl;

                    std::cout << "rotation after" << std::endl;
                    rl::math::Vector3 angles = x_robot.rotation().eulerAngles(2, 1, 2);
                    std::cout << angles[0] * rl::math::constants::rad2deg << " " << angles[1] * rl::math::constants::rad2deg << " " << angles[2] * rl::math::constants::rad2deg << std::endl;
                     */
                    //}

#ifdef RL_MDL_NLOPT
                    rl::mdl::NloptInverseKinematics ik(kinematic.get());
#else
                    rl::mdl::JacobianInverseKinematics ik(kinematic.get());
                    ik.setDelta(0.5f);
#endif

#ifndef NDEBUG
                    ik.setDuration(std::chrono::seconds(2));
#endif
                    ik.addGoal(x_robot, 0);

                    /*std::stringstream ss1;

                    ss1 << "IK start pos = " << std::endl << kinematic->getPosition().transpose() << std::endl;
                    logger->info(ss1.str());


                    std::stringstream msg;
                    msg << x_robot.matrix() <<
                            std::endl << " rot: " << std::endl << x_robot.rotation().eulerAngles(2, 1, 0)*RAD_TO_DEG << std::endl;

                    logger->info("IK target: \n{}",
                                 msg.str());
*/

                    rl::math::Vector lb = kinematic->getMinimum();
                    rl::math::Vector ub = kinematic->getMaximum();

                    for (unsigned int i = 0; i < kinematic->getDofPosition(); i++) {
                        // only use axisBounds if not 0
                        lb(i) = std::max(lb(i), lowerBounds.size() <= i ? lb(i) : lowerBounds[i]);
                        ub(i) = std::min(ub(i), upperBounds.size() <= i ? ub(i) : upperBounds[i]);
                    }

                    std::stringstream ss;

                    //ss << "lb = " << lb.transpose() << " ub = " << ub.transpose() << std::endl;
                    //logger->info("Kinematic bounds: {}", ss.str());
#ifdef RL_MDL_NLOPT
                    ik.setLowerBound(lb);
                    ik.setUpperBound(ub);
#endif

                    if (!ik.solve()) {
                        logger->error("Can not calculate inverse position.");
                        return false;
                    }

                    joints = kinematic->getPosition();
                    //kinematic->setPosition(joints);
                    kinematic->forwardPosition();
                    rl::math::Transform t1 = kinematic->getOperationalPosition(0);

                    //if(t1.distance(x_robot, 0.1)>0.1 && false){
                    if (t1.distance(x_robot, 0.1) > 0.1) {
                        logger->error("There is a difference between desired and calculated positon, MOVE FAILED");
                        return false;
                    }

                    return true;
                }

                virtual void step(rl::mdl::Dynamic *kinematicRunner) = 0;

                virtual bool isActive() = 0;

                bool jointTargetReached(const rl::math::Vector &targetPosition) const {
                    rl::math::Vector current = getJointPosition();

                    rl::math::Vector diff = current - targetPosition;

                    for (unsigned i = 0; i < this->kinematic->getDof(); i++) {
                        if (fabs(diff[i]) >= jointDelta)
                            return false;
                    }
                    return true;

                }


                bool cartesianTargetReached(const ::rl::math::Transform &targetPosition, rl::mdl::Dynamic* kinematicSafe) {


                    rl::math::Vector q0 = getJointPosition();
                    kinematicSafe->setPosition(q0);
                    kinematicSafe->forwardPosition();
                    ::rl::math::Transform x0 = kinematicSafe->getOperationalPosition(0);

                    // in meter
                    rl::math::Real distTranslation = (x0.translation() -
                                                      targetPosition.translation()).norm();

                    // in rad
                    rl::math::Real distOrientation = (rl::math::Quaternion(x0.linear()).angularDistance(
                            rl::math::Quaternion(targetPosition.linear())));

                    return distTranslation < cartesianDeltaTranslation && distOrientation < cartesianDeltaRotation;

                }


            public:
                explicit RLSkillImpl(
                        std::shared_ptr<spdlog::logger> logger,
                        std::function<const rl::math::Vector()> getJointPosition,
                        std::shared_ptr<rl::mdl::Dynamic> kinematic) :
                        logger(std::move(logger)),
                        kinematic(std::move(kinematic)),
                        getJointPosition(std::move(getJointPosition)) {

                }

                friend class RlRobotDevice;

            };
        }
    }
}


#endif //ROBOTICS_RLSKILLIMPL_HPP
