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

if [[ "$CC" == *"clang"* ]]; then
	echo -e "\n=== Running static code analysis (clang) ==="
	mkdir -p build
	cd build
	scan-build-9 cmake -G "Unix Makefiles" ..
	scan-build-9 -enable-checker security.FloatLoopCounter \
	  -enable-checker security.insecureAPI.UncheckedReturn \
	  --status-bugs -v \
	  make -j 8
else
	echo -e "\n=== Running static code analysis (cppcheck) ==="
	cppcheck --template "{file}({line}): {severity} ({id}): {message}" \
		--enable=style --force --std=c++11 -j 8 \
		--suppress=incorrectStringBooleanError \
		--suppress=passedByValue \
		--suppress=invalidscanf --inline-suppr \
		$@ 2> cppcheck.txt
	if [ -s cppcheck.txt ]; then
		echo "\n\n====== CPPCHECK Static Analysis Errors ======"
		cat cppcheck.txt
		exit 1
	fi
fi
