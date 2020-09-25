#!/bin/bash

set -eE
errorTrap() {
    last_rv=$?
    if [ $last_rv -ne 0 ] ; then
        echo ""
        echo ""
        echo "----------------- Error -----------------"
        echo ""
        echo "---- Check additional output above!! ----"
        # Wait a bit until the stdout is flushed
        for i in 1 2 3 4 5 6 7 8 9 10; do echo "."; sleep 1; done
    fi
    exit $last_rv
}

trap errorTrap 0

if [ $# -ne 1 ]; then
    echo "Usage: script.sh PATH_TO_INSTALL"
    exit 1
fi

install_path=$1

mkdir $HOME/cli11_tmp_install
cd $HOME/cli11_tmp_install

git clone --branch v1.9.1 https://github.com/CLIUtils/CLI11.git
cd CLI11
#git submodule update --init --recursive

mkdir build && cd build

cmake -DCLI11_BUILD_TESTS=OFF -DCLI11_BUILD_EXAMPLES=OFF -DCMAKE_BUILD_TYPE=RelWithDebInfo -DCMAKE_INSTALL_PREFIX=$install_path ..
make -j3 install
cd $HOME

rm -rf $HOME/cli11_tmp_install