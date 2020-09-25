/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef PROJECT_CARTESIANLINEARPOSITIONACTUATOR_HPP
#define PROJECT_CARTESIANLINEARPOSITIONACTUATOR_HPP

#include <rl/math/Transform.h>

class CartesianPositionLinearActuator {
public:
    CartesianPositionLinearActuator() = default;

    virtual ~CartesianPositionLinearActuator() = default;

    virtual void setCartesianPositionLinear(const rl::math::Transform &x) = 0;
};

#endif //PROJECT_CARTESIANLINEARPOSITIONACTUATOR_HPP
