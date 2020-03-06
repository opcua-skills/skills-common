#!/bin/bash

set -e

DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" >/dev/null && pwd )"
pushd $(pwd)
cd $DIR/model_compiler
./PublishModel.sh $DIR/OpcUaRoboticsModel Robotics $DIR/Published
popd
