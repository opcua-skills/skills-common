//
// Created by breitkreuz on 11/12/2019.
//

#ifndef ROBOTICS_FORCETORQUESENSORSIM_H
#define ROBOTICS_FORCETORQUESENSORSIM_H

#include <rl/hal/SixAxisForceTorqueSensor.h>
#include <rl/hal/CyclicDevice.h>
#include <random>

namespace fortiss {
    namespace opcua {
        class ForceTorqueSensorSim : public rl::hal::SixAxisForceTorqueSensor,
                                     public rl::hal::CyclicDevice {
        public:
            explicit ForceTorqueSensorSim(const double forceExpectedVal = 30, const double forceStandardDev = 2,
                                          const double torqueExpectedVal = 30, const double torqueStandardDev = 2,
                                          const std::chrono::nanoseconds updateRate = std::chrono::nanoseconds(0))
                    : CyclicDevice(updateRate),
                      gen(rd()),
                      forceRand(forceExpectedVal, forceStandardDev),
                      torqueRand(torqueExpectedVal, torqueStandardDev) {}

            void step() override {
                for (int i = 0; i < 3; i++) {
                    forces[i] = forceRand(gen);
                    torques[i] = torqueRand(gen);
                }
            }

            rl::math::Vector getForces() const override {
                return forces;
            }

            // TODO
            std::size_t getForcesCount() const override {
                return 0;
            }

            // TODO
            rl::math::Real getForcesMaximum(const std::size_t &i) const override {
                return 0;
            }

            // TODO
            rl::math::Real getForcesMinimum(const std::size_t &i) const override {
                return 0;
            }

            rl::math::Vector getTorques() const override {
                return torques;
            }

            // TODO
            std::size_t getTorquesCount() const override {
                return 0;
            }

            // TODO
            rl::math::Real getTorquesMaximum(const std::size_t &i) const override {
                return 0;
            }

            // TODO
            rl::math::Real getTorquesMinimum(const std::size_t &i) const override {
                return 0;
            }

            rl::math::Vector getForcesTorques() const override {
                rl::math::Vector6 out;
                for (int i = 0; i < 3; i++) {
                    out[i] = forces[i];
                }
                for (int i = 0; i < 3; i++) {
                    out[i+3] = torques[i];
                }
                return out;
            }

            // TODO
            rl::math::Real getForcesTorquesMaximum(const std::size_t &i) const override {
                return 0;
            }

            // TODO
            rl::math::Real getForcesTorquesMinimum(const std::size_t &i) const override {
                return 0;
            }

            // TODO
            void open() override {}

            // TODO
            void close() override {}

            // TODO
            void start() override {}

            // TODO
            void stop() override {}

        private:
            std::random_device rd;
            std::mt19937 gen;
            std::normal_distribution<> forceRand;
            std::normal_distribution<> torqueRand;

            rl::math::Vector3 forces;
            rl::math::Vector3 torques;
        };
    }
}


#endif //ROBOTICS_FORCETORQUESENSORSIM_H
