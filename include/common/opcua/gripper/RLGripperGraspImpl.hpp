//
// Created by profanter on 13/12/2019.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_COMMON_RLGRIPPERGRASPIMPL_HPP
#define ROBOTICS_COMMON_RLGRIPPERGRASPIMPL_HPP

#include "later.hpp"
#include "RLGripperImpl.hpp"

namespace fortiss {
    class RLGripperGraspImpl
            : virtual public opcua::gripper::RLGripperImpl {

    public:
        explicit RLGripperGraspImpl(const std::shared_ptr<spdlog::logger>& logger, rl::hal::Gripper *gripper, bool simulation) :
                RLGripperImpl(logger, gripper, simulation) {

        }

        virtual ~RLGripperGraspImpl() = default;

        bool start() override {
            if (isMoving) {
                logger->error("Gripper is still moving");
                return false;
            }
            logger->info("Got release gripper");

            if (startMoveGripperCallback && !startMoveGripperCallback()) {
                return false;
            }

            isMoving = true;
            if (simulation) {
                logger->info("Gripper RELEASE");
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

#endif //ROBOTICS_COMMON_RLGRIPPERGRASPIMPL_HPP
