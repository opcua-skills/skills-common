//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOT_PTPINTERPOLATOR_HPP
#define ROBOT_PTPINTERPOLATOR_HPP

#include <rl/math/Polynomial.h>
#include <rl/math/Spline.h>
#include <iostream>

#include "Interpolator.hpp"

namespace fortiss {
    namespace opcua {
        namespace robot {
            class PtpInterpolator : public Interpolator {
            private:

                ::rl::math::Vector q0;

                ::rl::math::Vector q1;

                rl::math::Spline<rl::math::Vector> interpolated;

                ::rl::math::Vector maxVelocity;
                ::rl::math::Vector maxAcceleration;
                ::rl::math::Vector maxJerk;

            public:
                explicit PtpInterpolator(const std::shared_ptr<rl::mdl::Dynamic> &kinematic,
                                         const ::rl::math::Vector &q0,
                                         const ::rl::math::Vector &q1,
                                         const ::rl::math::Vector _maxVelocity = rl::math::Vector(),
                                         const ::rl::math::Vector _maxAcceleration = rl::math::Vector(),
                                         const ::rl::math::Vector _maxJerk = rl::math::Vector()) :
                        Interpolator(kinematic),
                        q0(q0),
                        q1(q1),
                        maxVelocity(_maxVelocity),
                        maxAcceleration(_maxAcceleration),
                        maxJerk(_maxJerk) {


                    if (maxVelocity.size() == 0 || maxVelocity.isZero(0))
                        maxVelocity = this->kinematic->getSpeed();
                    if (maxAcceleration.size() == 0 || maxAcceleration.isZero(0))
                        maxAcceleration = rl::math::Vector::Constant(kinematic->getDofPosition(),
                                                                     5.0);
                    if (maxJerk.size() == 0 || maxJerk.isZero(0))
                        maxJerk = rl::math::Vector::Constant(kinematic->getDofPosition(),
                                                                     50.0);


                    interpolated = rl::math::Spline<rl::math::Vector>::TrapezoidalAccelerationAtRest(
                            q0, q1, maxVelocity, maxAcceleration, maxJerk);

                }

                virtual ~PtpInterpolator() = default;

                ::rl::math::Real getDuration() const override {
                    return this->interpolated.duration();
                }

                bool isValid(std::chrono::nanoseconds updateRate) {
                    //TODO Markus: pre-check valid joint limits and speed limit

                    std::pair<::rl::math::Real, size_t> timeSteps = getTimeStep(updateRate);

                    for (size_t i = 0; i < timeSteps.second; i++) {
                        ::rl::math::Real ti0 = (double)i * timeSteps.first;
                        ::rl::math::Real ti1 = i + 1 == timeSteps.second ? getDuration() : ((double)i + 1) * timeSteps.first;

                        ::rl::math::Vector qi0 = this->interpolated(::std::min(ti0, this->interpolated.duration()));
                        ::rl::math::Vector qi1;
                        ::rl::math::Vector qdi1;

                        if (!getInterpolatedJointPosition(this->kinematic.get(), qi0, ti1, updateRate, &qi1, &qdi1)) {
                            std::cout << "ERROR: Speed limits exceeded in step " << i << " with "
                                      << qi1.transpose() * rl::math::RAD2DEG << std::endl;
                            return false;
                        }

                        if (!this->kinematic->isValid(qi1)) {
                            std::cout << "ERROR: joint limits exceeded in step " << i << " with "
                                      << qi1.transpose() * rl::math::RAD2DEG << std::endl;
                            return false;
                        }

                    }

                    return true;
                }

                bool getInterpolatedJointPosition(
                        rl::mdl::Dynamic *kinematicRunner,
                        const ::rl::math::Vector &qi0,
                        const ::rl::math::Real &t,
                        const std::chrono::nanoseconds &updateRate,
                        ::rl::math::Vector *qi1,
                        ::rl::math::Vector *qdi1) const {

                    *qi1 = this->interpolated(::std::min(t, this->interpolated.duration()));

                    rl::math::Vector diff = *qi1 - qi0;

                    *qdi1 = diff / ((double)updateRate.count() / 1000000.0);

                    if (((*qdi1) - maxVelocity).maxCoeff() > 0) {
                        std::cout << "ERROR: maxVelocity exceeded" << std::endl;
                        return false;
                    }

                    //TODO also check acceleration

                    return true;
                }
            };
        }
    }
}

#endif //ROBOT_PTPINTERPOLATOR_HPP
