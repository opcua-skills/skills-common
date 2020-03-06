//
// Created by breitkreuz on 05/02/19.
//

#ifndef PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP
#define PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP

class JointPositionLinearActuator {
public:
    JointPositionLinearActuator() = default;

    virtual ~JointPositionLinearActuator() = default;

    virtual void setJointPositionLinear(const rl::math::Vector &q) = 0;
};

#endif //PROJECT_JOINTLINEARPOSITIONACTUATOR_HPP
