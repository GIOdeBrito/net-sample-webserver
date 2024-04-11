#!/bin/sh

# Stop
docker stop $(docker ps -aq)

# Kill all containers
docker rm $(docker ps -aq)