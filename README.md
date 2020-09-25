# common

Common configuration and source files for all components.

**NOTE:**

This repository is just an example code and should not be used in any production environment or in a bigger community.
We do currently not accept pull requests. 

## Dependencies

A full list of dependencies which are required for building this repo should be taken from the corresponding docker image configuration:

[main.yml](.gihtub/workflows/main.yml)


To summarize, you will need the following packages:

`libconfig++-dev`, open62541, cli11, and a current RoboticsLibrary version.

## Building the Docker image for CI

Check out the corresponding [ci/README.md](ci/README.md)