//
// Created by breitkreuz on 05/02/19.
//

#ifndef PROJECT_CARTESIANVELOCITYACTUATOR_HPP
#define PROJECT_CARTESIANVELOCITYACTUATOR_HPP

class CartesianVelocityActuator {
public:
    CartesianVelocityActuator() = default;

    virtual ~CartesianVelocityActuator() = default;

    virtual void setCartesianVelocity(const double &xd) = 0;
};

#endif //PROJECT_CARTESIANVELOCITYACTUATOR_HPP
