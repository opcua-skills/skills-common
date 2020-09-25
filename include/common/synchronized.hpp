/*
 * This file is subject to the terms and conditions defined in
 * file 'LICENSE', which is part of this source code package.
 *
 *    Copyright (c) 2020 fortiss GmbH, Stefan Profanter
 *    All rights reserved.
 */

#ifndef FORTISS_COMMON_SYNCHRONIZED_HPP
#define FORTISS_COMMON_SYNCHRONIZED_HPP

#include <memory>
#include <mutex>
#include <thread>
#include <vector>

// Source:
// https://stackoverflow.com/a/23613149/869402

template <typename BasicLockable>
class unlock_deleter {
    std::unique_lock<BasicLockable> lock_;
public:
    unlock_deleter(BasicLockable& mtx) : lock_{mtx} {}
    unlock_deleter(BasicLockable& mtx, std::adopt_lock_t a) noexcept : lock_{mtx, a} {}

    template <typename T>
    void operator () (T*) const noexcept {
        // no-op
    }
};

template <typename T, typename M = std::mutex>
using locked_ptr = std::unique_ptr<T, unlock_deleter<M>>;

template <typename T, typename M = std::mutex>
class synchronized {
    T* item_;
    mutable M mtx_;

    // Implement Copy/Move construction
    template <typename Other, typename N>
    synchronized(Other&& other, const std::lock_guard<N>&) :
            item_{std::forward<Other>(other).item_} {}

    // Implement Copy/Move assignment
    template <typename Other>
    void assign(Other&& other) {
        std::lock(mtx_, other.mtx_);
        std::lock_guard<M> _{mtx_, std::adopt_lock};
        std::lock_guard<decltype(other.mtx_)> _o{other.mtx_, std::adopt_lock};
        item_ = std::forward<Other>(other).item_;
    }

public:
    synchronized() = default;
    synchronized(T* other) {
        item_ = other;
    }

    synchronized(const synchronized& other) :
            synchronized(other, std::lock_guard<M>(other.mtx_)) {}
    template <typename N>
    synchronized(const synchronized<T, N>& other) :
            synchronized(other, std::lock_guard<N>(other.mtx_)) {}

    synchronized(synchronized&& other) :
            synchronized(std::move(other), std::lock_guard<M>(other.mtx_)) {}
    template <typename N>
    synchronized(synchronized<T, N>&& other) :
            synchronized(std::move(other), std::lock_guard<N>(other.mtx_)) {}



    synchronized& operator = (const synchronized& other) & {
        if (&other != this) {
            assign(other);
        }
        return *this;
    }
    template <typename N>
    synchronized& operator = (const synchronized<T, N>& other) & {
        assign(other);
        return *this;
    }

    synchronized& operator = (synchronized&& other) & {
        if (&other != this) {
            assign(std::move(other));
        }
        return *this;
    }
    template <typename N>
    synchronized& operator = (synchronized<T, N>&& other) & {
        assign(std::move(other));
        return *this;
    }

    template <typename N>
    void swap(synchronized<T, N>& other) {
        if (static_cast<void*>(&other) != static_cast<void*>(this)) {
            std::lock(mtx_, other.mtx_);
            std::lock_guard<M> _{mtx_, std::adopt_lock};
            std::lock_guard<N> _o{other.mtx_, std::adopt_lock};

            using std::swap;
            swap(item_, other.item_);
        }
    }

    locked_ptr<T, M> data() & {
        return locked_ptr<T, M>{item_, mtx_};
    }
    locked_ptr<const T, M> data() const& {
        return locked_ptr<const T, M>{item_, mtx_};
    }
};

template <typename T, typename M, typename N>
void swap(synchronized<T, M>& a, synchronized<T, N>& b) {
    a.swap(b);
}

#endif //FORTISS_COMMON_SYNCHRONIZED_HPP
