//
// Created by profanter on 13/12/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_RLGRIPPERRELEASEIMPL_HPP
#define ROBOTICS_COMMON_RLGRIPPERRELEASEIMPL_HPP

#include "later.hpp"
#include "RLGripperImpl.hpp"

namespace fortiss {
    class RLGripperReleaseImpl
            : virtual public opcua::gripper::RLGripperImpl {

    public:
        explicit RLGripperReleaseImpl(const std::shared_ptr<spdlog::logger>& logger, rl::hal::Gripper *gripper, bool simulation) :
                RLGripperImpl(logger, gripper, simulation) {

        }

        virtual ~RLGripperReleaseImpl() = default;

        bool start() override {
            if (isMoving) {
                logger->error("Gripper is still moving");
                return false;
            }
            logger->info("Got grasp gripper");

            if (startMoveGripperCallback && !startMoveGripperCallback()) {
                return false;
            }

            isMoving = true;
            if (simulation) {
                logger->info("Gripper GRASP");
                later laterTask(1000, true, [this]() {
                    logger->info("Gripper finished");
                    isMoving = false;
                    this->moveFinished();
                });
            }
            else {
                gripper->release();
            }
            return true;
        };

        bool halt() override {
            logger->info("Got halt move");
            gripper->stop();
            isMoving = false;
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

    };
}

#endif //ROBOTICS_COMMON_RLGRIPPERRELEASEIMPL_HPP
