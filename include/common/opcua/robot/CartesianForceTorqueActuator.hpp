//
// Created by breitkreuz on 8/02/19.
//

#ifndef ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP
#define ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP

#include <rl/math/Vector.h>

class CartesianForceTorqueActuator {
public:
    virtual void
    setCartesianForceTorqueLimit(const rl::math::Vector3 &maxForce, const rl::math::Vector3 &maxTorque) = 0;
};

#endif //ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP
