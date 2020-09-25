/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_COMMON_RLGRIPPERIMPL_HPP
#define ROBOTICS_COMMON_RLGRIPPERIMPL_HPP


#include <rl/hal/Gripper.h>

#include <utility>
#include "later.hpp"

namespace fortiss {
    namespace opcua {
        namespace gripper {

            enum RlGripperState {
                GRIPPER_STATE_IDLE = 0,
                GRIPPER_STATE_MOVING = 1,
                GRIPPER_STATE_ERROR = 2
            };

            class RLGripperImpl
                    : virtual public fortiss::opcua::skill::gripper::GraspReleaseGripperSkillImpl {

            protected:

                bool isMoving = false;
                std::chrono::steady_clock::time_point skillStartTime;
                const std::shared_ptr<spdlog::logger> logger;
                bool simulation;


                rl::hal::Gripper *gripper;

            public:
                explicit RLGripperImpl(std::shared_ptr<spdlog::logger>  logger, rl::hal::Gripper *gripper, bool simulation) :
                        GraspReleaseGripperSkillImpl(),
                        skillStartTime(),
                        logger(std::move(logger)),
                        simulation(simulation), gripper(gripper) {

                }

                virtual ~RLGripperImpl() = default;

                std::function<RlGripperState()> getGripperState = nullptr;

                void step() {
                    if (!isMoving)
                        return;

                    auto state = getGripperState();

                    switch (state) {
                        case GRIPPER_STATE_ERROR:
                            this->moveErrored();
                            isMoving = false;
                            break;
                        case GRIPPER_STATE_MOVING:
                            break;
                        case GRIPPER_STATE_IDLE:
                            this->moveErrored();
                            isMoving = false;
                            break;
                    }
                }

                std::function<bool()> startMoveGripperCallback;
            };
        }
    }
}


#endif //ROBOTICS_COMMON_RLGRIPPERIMPL_HPP
