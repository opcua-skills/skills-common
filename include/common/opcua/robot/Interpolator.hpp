//
// Created by profanter on 21/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_INTERPOLATOR_HPP
#define ROBOTICS_INTERPOLATOR_HPP

#include <rl/math/Array.h>
#include <rl/math/Real.h>
#include <rl/math/algorithm.h>
#include <rl/mdl/Kinematic.h>
#include <rl/mdl/Dynamic.h>

namespace fortiss {
    namespace opcua {
        namespace robot {
            class Interpolator {

            public:

                explicit Interpolator(const std::shared_ptr<rl::mdl::Dynamic> &kinematic):
                        kinematic(kinematic)
                        /*maximumAcceleration(100 * ::rl::math::DEG2RAD),
                        maximumAccelerationPercentage(1),
                        maximumSpeedPercentage(1)*/ {

                }

                virtual ~Interpolator() = default;

                /*::rl::math::Real
                getMaximumAcceleration() const
                {
                    return this->maximumAcceleration;
                }

                ::rl::math::Real
                getMaximumAccelerationPercentage() const
                {
                    return this->maximumAccelerationPercentage;
                }

                ::rl::math::Real
                getMaximumSpeedPercentage() const
                {
                    return this->maximumSpeedPercentage;
                }*/

                ::rl::math::Real
                getMinimumDurationPercentage(const ::rl::math::Real& maxSpeedPercentage, const ::rl::math::Real& maxAcceleration, ::rl::math::ArrayX vMax, ::rl::math::ArrayX aMax) const
                {
                    ::rl::math::Vector speed = this->kinematic->getSpeed() * maxSpeedPercentage;

                    ::rl::math::Real velocityOverload = (vMax / speed.array()).maxCoeff();
                    ::rl::math::Real accelerationOverload = (aMax / maxAcceleration).maxCoeff();

                    return ::std::max(velocityOverload, ::std::sqrt(accelerationOverload));
                }

                ::rl::math::Real
                getMinimumDurationValues(const ::rl::math::Vector& maxSpeed, const ::rl::math::Vector& maxAcceleration, ::rl::math::ArrayX vMax, ::rl::math::ArrayX aMax) const
                {

                    ::rl::math::Real velocityOverload = (vMax / maxSpeed.array()).maxCoeff();
                    ::rl::math::Real accelerationOverload = (aMax / maxAcceleration.array()).maxCoeff();

                    return ::std::max(velocityOverload, ::std::sqrt(accelerationOverload));
                }

                ::rl::math::Real
                getMinimumDurationValues(const ::rl::math::Vector& maxSpeed, const ::rl::math::Vector& maxAcceleration, ::rl::math::Real vMax, ::rl::math::Real aMax) const
                {

                    ::rl::math::Real velocityOverload = (vMax / maxSpeed.array()).maxCoeff();
                    ::rl::math::Real accelerationOverload = (aMax / maxAcceleration.array()).maxCoeff();

                    return ::std::max(velocityOverload, ::std::sqrt(accelerationOverload));
                }

                /*void
                setMaximumAcceleration(const ::rl::math::Real& maxAcceleration)
                {
                    this->maximumAcceleration = ::std::max(static_cast< ::rl::math::Real>(0), maxAcceleration);
                }

                void
                setMaximumAccelerationPercentage(const ::rl::math::Real& maxAccelerationPercentage)
                {
                    this->maximumAccelerationPercentage = ::rl::math::clamp(maxAccelerationPercentage, static_cast< ::rl::math::Real>(0), static_cast< ::rl::math::Real>(1));
                }

                void
                setMaximumSpeedPercentage(const ::rl::math::Real& maxSpeedPercentage)
                {
                    this->maximumSpeedPercentage = ::rl::math::clamp(maxSpeedPercentage, static_cast< ::rl::math::Real>(0), static_cast< ::rl::math::Real>(1));
                }*/

                /*void
                setMinimumDuration(const ::rl::math::Real& maxSpeedPercentage, const ::rl::math::Real& maxAcceleration)
                {
                    this->setDuration(this->getMinimumDuration(maxSpeedPercentage, maxAcceleration));
                }*/


                std::pair<::rl::math::Real, size_t> getTimeStep(::std::chrono::nanoseconds updateRate) {
                    ::rl::math::Real suggestedTimeStep = ::std::chrono::duration_cast< ::std::chrono::duration< ::rl::math::Real>>(updateRate).count();
                    ::std::size_t steps = static_cast< ::std::size_t>(::std::ceil(getDuration() / suggestedTimeStep)) + 1;
                    return std::pair<::rl::math::Real, size_t>(getDuration() / static_cast< ::rl::math::Real>(steps), steps);
                }

            protected:
                const std::shared_ptr<rl::mdl::Dynamic> kinematic;

                //::rl::math::Real maximumAcceleration;

                //::rl::math::Real maximumAccelerationPercentage;

                //::rl::math::Real maximumSpeedPercentage;

                virtual ::rl::math::Real getDuration() const = 0;
                //virtual void setDuration(const ::rl::math::Real& duration) = 0;
            };
        }
    }
}

#endif //ROBOTICS_INTERPOLATOR_HPP
