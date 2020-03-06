#!/bin/bash

set -e

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null && pwd )"
pushd $(pwd)
cd $DIR/deps/device/model_compiler
./PublishModel.sh $DIR/fortissRoboticsModel fortiss_Robotics $DIR/Published
popd
