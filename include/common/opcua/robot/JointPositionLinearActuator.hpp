/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP
#define PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP

class JointPositionLinearActuator {
public:
    JointPositionLinearActuator() = default;

    virtual ~JointPositionLinearActuator() = default;

    virtual void setJointPositionLinear(const rl::math::Vector &q) = 0;
};

#endif //PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP
