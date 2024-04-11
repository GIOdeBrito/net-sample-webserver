#!/bin/sh

PROJECT_NAME="CSharp-Web"
CONTAINER_NAME="csharp-container";
IMAGE_NAME="csharp-image"

echo "\nBuilding $PROJECT_NAME application...\n";
dotnet build csharp-web.csproj -c Release

# If a container with the same name is active, destroy it
if docker ps --format '{{.Names}}' | grep -q "^$CONTAINER_NAME$"; then
    docker stop $CONTAINER_NAME;
    docker rm $CONTAINER_NAME
    echo "\nDestroying older container...\n"
fi

docker build -t $IMAGE_NAME .

# Runs container on background on port 8080. And on port 5000 in the current machine 
docker run -d -p 5000:8080 --name $CONTAINER_NAME $IMAGE_NAME

echo "\nRunning $PROJECT_NAME application...\n"

# Enter inside container
# docker exec -it csharp-container /bin/bash