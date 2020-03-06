//
// Created by breitkreuz on 05/02/19.
//

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
