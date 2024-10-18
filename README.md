# .NET Sample Web Server
This is a sample ASP.NET web server made with C# 8.0.

## Requirements
- Docker
- A Linux machine

## Running
To run the project first it is necessary to build it with docker.
```bash
sudo docker-compose build
```

After that, run the project.
```bash
sudo docker-compose up -d
```

## Logging
The logs, messages and thrown errors, can be seen with a docker command.
```bash
sudo docker logs main-net-website
```