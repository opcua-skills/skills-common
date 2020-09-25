/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef PROJECT_CARTESIANVELOCITYACTUATOR_HPP
#define PROJECT_CARTESIANVELOCITYACTUATOR_HPP

class CartesianVelocityActuator {
public:
    CartesianVelocityActuator() = default;

    virtual ~CartesianVelocityActuator() = default;

    virtual void setCartesianVelocity(const double &xd) = 0;
};

#endif //PROJECT_CARTESIANVELOCITYACTUATOR_HPP
