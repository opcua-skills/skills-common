#!/bin/bash


DEFAULT_VERSION=master

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

if [ $# -gt 2 ]; then
    echo "Usage: script.sh COMMIT_ID PATH_TO_INSTALL"
    exit 1
fi

if [ $# -eq 1 ]; then
    commit_id=$DEFAULT_VERSION
    install_path=$1
else
    commit_id=$1
    install_path=$2
fi

if [[ -z "${CI}" ]]; then
    rm -rf $install_path
fi

mkdir $HOME/open62541_tmp_install
cd $HOME/open62541_tmp_install

git clone https://github.com/open62541/open62541.git
cd open62541
git checkout ${commit_id}
git submodule update --init --recursive

mkdir build && cd build

cmake -DCMAKE_INSTALL_PREFIX=${install_path} -DUA_ENABLE_ENCRYPTION=ON -DUA_ENABLE_SUBSCRIPTIONS_EVENTS=ON -DUA_NAMESPACE_ZERO=FULL -DUA_ENABLE_DISCOVERY_MULTICAST=ON -DBUILD_SHARED_LIBS=ON ..
make -j3 install
cd $HOME

rm -rf $HOME/open62541_tmp_install