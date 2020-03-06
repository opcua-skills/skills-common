//
// Created by profanter on 17/05/19.
// Copyright (c) 2019 fortiss GmbH. All rights reserved.
//

#ifndef ROBOTICS_SKILLS_SKILLIMPL_HPP
#define ROBOTICS_SKILLS_SKILLIMPL_HPP

#include "SkillRunMutex.hpp"

namespace fortiss {

    namespace opcua {
        namespace skill {

            class SkillImpl {

            private:

                std::vector<SkillRunMutex*> runMutex;

            public:
                explicit SkillImpl(): runMutex() {

                }

                void addRunMutex(SkillRunMutex* mutex) {
                    runMutex.push_back(mutex);
                }
            };
        }
    }
}

#endif //ROBOTICS_SKILLS_SKILLIMPL_HPP
