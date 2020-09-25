/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP
#define ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP

#include <rl/math/Vector.h>

class CartesianForceTorqueActuator {
public:
    virtual void
    setCartesianForceTorqueLimit(const rl::math::Vector3 &maxForce, const rl::math::Vector3 &maxTorque) = 0;
};

#endif //ROBOTICS_CARTESIANFORCELIMITACTUATOR_HPP
