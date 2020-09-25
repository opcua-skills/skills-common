/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

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
                explicit SkillImpl() : runMutex() {

                }

                void addRunMutex(SkillRunMutex* mutex) {
                    runMutex.push_back(mutex);
                }
            };
        }
    }
}

#endif //ROBOTICS_SKILLS_SKILLIMPL_HPP
