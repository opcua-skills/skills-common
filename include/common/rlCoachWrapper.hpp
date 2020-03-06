//
// Created by profanter on 27/01/2020.
// Copyright (c) 2020 fortiss GmbH. All rights reserved.
//

#ifndef SEMANTIC_MES_RLCOACHWRAPPER_H
#define SEMANTIC_MES_RLCOACHWRAPPER_H

#include <rl/hal/Socket.h>
#include <rl/hal/CyclicDevice.h>
#include <rl/mdl/Transform.h>

class rlCoachWrapper : public rl::hal::CyclicDevice {
public:
    explicit rlCoachWrapper(
            const ::std::chrono::nanoseconds& updateRate = std::chrono::milliseconds(10),
            const ::std::string& hostname = "localhost",
            const unsigned short int& port = 11235
    ) :
            rl::hal::CyclicDevice(updateRate),
            out(),
            socket(rl::hal::Socket::Tcp(rl::hal::Socket::Address::Ipv4(hostname, port))) {

    }

    virtual ~rlCoachWrapper() = default;

    void close() {
        this->socket.close();
        this->setConnected(false);
    }

    void open() {
        this->socket.open();
        this->socket.connect();
        this->setConnected(true);
    }

    void start() {
        this->setRunning(true);
    }

    void step() {
        ::std::chrono::steady_clock::time_point start = ::std::chrono::steady_clock::now();
        {
            std::lock_guard<std::mutex> lock(runnerMutex);
            this->socket.send(this->out.str().c_str(), this->out.str().length());

            this->out.clear();
            this->out.str("");
        }

        ::std::this_thread::sleep_until(start + this->getUpdateRate());
    }

    void stop() {
        if (running) {
            running = false;

        }
        this->out.clear();
        this->out.str("");
        this->setRunning(false);
    }

    void runThreaded() {
        if (running)
            return;

        running = true;

        if (!this->isRunning())
            this->start();
        if (!this->isConnected())
            this->open();

        runner = std::thread([this]() {
            while(running)
                step();

            this->stop();
            this->close();
        });
    }

    void addConnection(
            size_t kinematicIdx,
            size_t endeffectorIdx,
            size_t modelIdx,
            size_t bodyIdx,
            const rl::math::Transform& offset,
            const std::string& uuid
    ) {

        std::lock_guard<std::mutex> lock(runnerMutex);
        rl::math::Vector3 vec = offset.rotation().eulerAngles(2, 1, 0).reverse();
        this->out << 20 << " "
                  << kinematicIdx << " "
                  << endeffectorIdx << " "
                  << modelIdx << " "
                  << bodyIdx << " "
                  << offset.translation().x() << " "
                  << offset.translation().y() << " "
                  << offset.translation().z() << " "
                  << vec.x() << " "
                  << vec.y() << " "
                  << vec.z() << " "
                  << uuid << ::std::endl;
    }

    void addConnection(
            size_t kinematicIdx,
            size_t endeffectorIdx,
            size_t modelIdx,
            size_t bodyIdx,
            const std::string& uuid
    ) {

        std::lock_guard<std::mutex> lock(runnerMutex);
        this->out << 20 << " "
                  << kinematicIdx << " "
                  << endeffectorIdx << " "
                  << modelIdx << " "
                  << bodyIdx << " "
                  << uuid << ::std::endl;
    }

    void removeConnection(
            const std::string& uuid
    ) {
        std::lock_guard<std::mutex> lock(runnerMutex);
        this->out << 21 << " " << uuid << ::std::endl;
    }

private:
    ::std::stringstream out;
    bool running = false;
    std::thread runner;
    std::mutex runnerMutex;

    rl::hal::Socket socket;

};


#endif //SEMANTIC_MES_RLCOACHWRAPPER_H
