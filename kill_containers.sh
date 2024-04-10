#!/bin/sh

# Kill all containers
docker rm $(docker ps -aq)