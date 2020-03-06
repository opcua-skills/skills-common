OPC UA Model Compiler
=====================

This repository contains the compiled version of https://github.com/Pro/UA-ModelCompiler/tree/hotfix/mono_build

The ModelCompiler is used to generate the corresponding NodeSet2.xml from the ModelDesign XML files.

The Design subfolder from here: https://github.com/OPCFoundation/UA-ModelCompiler/tree/master/ModelCompiler/Design
is required as dependency for your model files

## How to build from the repo

```bash
cd UA_ModelCompiler
xbuild "ModelCompiler Solution.sln" /p:TargetFrameworkVersion="v4.5"
cp Bin/Debug/* /path_to_this_repo/
cp ModelCompiler/Design/* /path_to_this_repo/Design/
```