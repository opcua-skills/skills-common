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
    install_prefix=""
else
	install_prefix=-DCMAKE_INSTALL_PREFIX:PATH=$1
fi


mkdir $HOME/rl_tmp_install
cd $HOME/rl_tmp_install

git clone https://github.com/roboticslibrary/rl
cd rl
#git submodule update --init --recursive

mkdir build && cd build

cmake -DRL_BUILD_PLAN=OFF -DRL_BUILD_DEMOS=ON -DRL_USE_QT5=OFF -DCMAKE_BUILD_TYPE=RelWithDebInfo $install_prefix ..
sudo make -j3 install
cd $HOME

rm -rf $HOME/rl_tmp_install