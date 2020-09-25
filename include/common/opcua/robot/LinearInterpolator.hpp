/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOT_LINEARINTERPOLATOR_HPP
#define ROBOT_LINEARINTERPOLATOR_HPP

#include <rl/math/Polynomial.h>
#include <rl/math/Spline.h>
#include "Interpolator.hpp"
#include <iostream>

namespace fortiss {
    namespace opcua {
        namespace robot {
            class LinearInterpolator : public Interpolator {

            private:

                rl::math::Spline<rl::math::Vector3> interpolatedOrientationChange;
                rl::math::Spline<rl::math::Vector3> interpolatedPosition;

                ::rl::math::Vector q0;
                ::rl::math::Vector q1;

                ::rl::math::Transform x0;

                ::rl::math::Transform x1;


                const ::rl::math::Vector3 maxPositionVelocity;
                const ::rl::math::Vector3 maxPositionAcceleration;
                const ::rl::math::Vector3 maxPositionJerk;
                const ::rl::math::Vector3 maxOrientationVelocity;
                const ::rl::math::Vector3 maxOrientationAcceleration;
                const ::rl::math::Vector3 maxOrientationJerk;

            public:
                explicit LinearInterpolator(const std::shared_ptr<rl::mdl::Dynamic> &kinematic,
                                            const ::rl::math::Vector &q0,
                                            const ::rl::math::Transform &x0,
                                            const ::rl::math::Vector &q1,
                                            const ::rl::math::Transform &x1,
                                            const ::rl::math::Vector3 _maxPositionVelocity = ::rl::math::Vector3::Constant(
                                                    10.0),
                                            const ::rl::math::Vector3 _maxPositionAcceleration = ::rl::math::Vector3::Constant(
                                                    50.0),
                                            const ::rl::math::Vector3 _maxPositionJerk = ::rl::math::Vector3::Constant(
                                                    500.0),
                                            const ::rl::math::Vector3 _maxOrientationVelocity = ::rl::math::Vector3::Constant(
                                                    1.0),
                                            const ::rl::math::Vector3 _maxOrientationAcceleration = ::rl::math::Vector3::Constant(
                                                    5.0),
                                            const ::rl::math::Vector3 _maxOrientationJerk = ::rl::math::Vector3::Constant(
                                                    50.0)) :
                        Interpolator(kinematic),
                        q0(q0),
                        q1(q1),
                        x0(x0),
                        x1(x1),
                        maxPositionVelocity(_maxPositionVelocity),
                        maxPositionAcceleration(_maxPositionAcceleration),
                        maxPositionJerk(_maxPositionJerk),
                        maxOrientationVelocity(_maxOrientationVelocity),
                        maxOrientationAcceleration(_maxOrientationAcceleration),
                        maxOrientationJerk(_maxOrientationJerk) {


                    interpolatedPosition =
                            rl::math::Spline<rl::math::Vector3>::TrapezoidalAccelerationAtRest(
                                    this->x0.translation(), this->x1.translation(), maxPositionVelocity,
                                    maxPositionAcceleration, maxPositionJerk);


                    ::rl::math::Quaternion h0(this->x0.linear());
                    ::rl::math::Quaternion h1(this->x1.linear());

                    rl::math::Real dtheta = h0.angularDistance(h1);
                    rl::math::Vector3 e = (h0.inverse() * h1).vec().normalized();

                    rl::math::Vector3 hStart = rl::math::Vector3::Zero();
                    rl::math::Vector3 hEnd = e * dtheta;
                    interpolatedOrientationChange =
                            rl::math::Spline<rl::math::Vector3>::TrapezoidalAccelerationAtRest(hStart, hEnd,
                                                                                               maxOrientationVelocity,
                                                                                               maxOrientationAcceleration,
                                                                                               maxOrientationJerk);



                }

                virtual ~LinearInterpolator() = default;

                ::rl::math::Real getDuration() const override {
                    return std::max(this->interpolatedPosition.duration(), this->interpolatedOrientationChange.duration());
                }

                bool isValid(::std::chrono::nanoseconds updateRate) {

                    /*this->unit.clear();
                    this->unit.lower() = 0;
                    this->unit.upper() = 0;*/

                    /*std::cout << "########### LIN Interpolation ##########" << std::endl;
                    std::cout << "q0 = " << this->q0.transpose() << std::endl;
                    std::cout << "q1 = " << this->q1.transpose() << std::endl;
                    std::cout << "x0 = " << x0.translation().x() << " m, y = " << x0.translation().y() << " m, z = "
                              << x0.translation().z() << " m, a = "
                              << x0.rotation().eulerAngles(2, 1, 0).reverse().x() * rl::math::constants::rad2deg
                              << " deg, b = " << x0.rotation().eulerAngles(2, 1, 0).reverse().y() * rl::math::constants::rad2deg
                              << " deg, c = "
                              << x0.rotation().eulerAngles(2, 1, 0).reverse().z() * rl::math::constants::rad2deg << " deg"
                              << std::endl;
                    std::cout << "x1 = " << x1.translation().x() << " m, y = " << x1.translation().y() << " m, z = "
                              << x1.translation().z() << " m, a = "
                              << x1.rotation().eulerAngles(2, 1, 0).reverse().x() * rl::math::constants::rad2deg
                              << " deg, b = " << x1.rotation().eulerAngles(2, 1, 0).reverse().y() * rl::math::constants::rad2deg
                              << " deg, c = "
                              << x1.rotation().eulerAngles(2, 1, 0).reverse().z() * rl::math::constants::rad2deg << " deg"
                              << std::endl;*/

                    ::rl::math::Vector qi0 = this->q0;
                    ::rl::math::Vector qi1(this->kinematic->getDofPosition());
                    ::rl::math::Transform xi0 = this->x0;

                    ::rl::math::Vector qdi0 = ::rl::math::Vector::Zero(this->kinematic->getDof());
                    ::rl::math::Vector qdi1(this->kinematic->getDof());

                    std::pair<::rl::math::Real, size_t> timeSteps = getTimeStep(updateRate);

                    //::rl::math::Quaternion h0(this->x0.linear());
                    //::rl::math::Quaternion h1(this->x1.linear());

                    ::rl::math::Transform xi1;
                    for (::std::size_t i = 0; i < timeSteps.second; ++i) {
                        //::rl::math::Real ti0 = i * timeStep;
                        ::rl::math::Real ti1 = i + 1 == timeSteps.second ? getDuration() : ((double)i + 1) * timeSteps.first;

                        bool success = getInterpolatedJointPosition(this->kinematic.get(), qi0, xi0, ti1, &qi1, &qdi1,
                                                                    &xi1);

                        if (!success)
                            return false;

                        //::rl::math::Polynomial<::rl::math::Vector> fi = ::rl::math::Polynomial<::rl::math::Vector>::CubicFirst(
                        //        qi0, qi1, qdi0, qdi1, ti1 - ti0);
                        //this->unit.push_back(fi);

                        qi0 = qi1;
                        qdi0 = qdi1;
                        xi0 = xi1;
                    }

                    return true;
                }

                bool getInterpolatedJointPosition(
                        rl::mdl::Dynamic *kinematicRunner,
                        const ::rl::math::Vector &qi0,
                        const ::rl::math::Transform &xi0,
                        const ::rl::math::Real &ti,
                        ::rl::math::Vector *qi1,
                        ::rl::math::Vector *qdi1,
                        ::rl::math::Transform *xi1) const {

                    //TODO Markus: Check speed limit

                    ::rl::math::Quaternion h0(x0.linear());

                    // todo return q1 if t > end
                    rl::math::Real tPos = ::std::min(ti, this->interpolatedPosition.duration());
                    rl::math::Real tOri = ::std::min(ti, this->interpolatedOrientationChange.duration());

                    xi1->translation() = this->interpolatedPosition(tPos);
                    rl::math::Vector3 axis = this->interpolatedOrientationChange(tOri);
                    rl::math::Real theta = axis.norm();
                    rl::math::Vector3 u;

                    if (theta <= std::numeric_limits<rl::math::Real>::epsilon())
                    {
                        u.setZero();
                    }
                    else
                    {
                        u = axis.normalized();
                    }
                    rl::math::Quaternion q = h0 * rl::math::AngleAxis(theta, u);
                    xi1->linear() = q.toRotationMatrix();
                    ::rl::math::Vector6 dx = xi0.toDelta(*xi1);

                    kinematicRunner->setPosition(qi0);
                    kinematicRunner->forwardPosition();
                    kinematicRunner->calculateJacobian();
                    kinematicRunner->calculateJacobianInverse();
                    ::rl::math::Vector dq = kinematicRunner->getJacobianInverse() * dx;

                    *qi1 = qi0 + dq;

                    if (!kinematicRunner->isValid(*qi1)) {
                        std::cout << "ERROR: joint limits exceeded with " << qi1->transpose() * rl::math::constants::rad2deg
                                  << std::endl;
                        return false;
                    }


                    // TODO set qdi1

/*
                    ::rl::math::Transform xdi1;
                    xdi1.translation() = this->interpolatedPosition(tPos);
                    rl::math::Vector3 axisd = this->interpolatedOrientationChange(tOri, 1);

                    rl::math::Real thetad = u.dot(axisd);
                    rl::math::Vector3 w = u.cross(axisd) / theta;
                    rl::math::Vector3 omega;

                    if (theta > std::numeric_limits<rl::math::Real>::epsilon())
                    {
                        omega = u * thetad + std::sin(theta) * w.cross(u) - (1 - std::cos(theta)) * w;
                    }
                    else
                    {
                        omega = axisd;
                    }

                    rl::math::Quaternion qd = q.firstDerivative(omega);
                    xdi1.linear() = qd.toRotationMatrix();

                    *qdi1 = kinematicRunner->getJacobianInverse() * xdi1;
*/

                    return true;

                }


            };
        }
    }
}

#endif //ROBOT_LINEARINTERPOLATOR_HPP
