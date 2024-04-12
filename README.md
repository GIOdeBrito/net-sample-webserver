# .NET Sample Web Server
This is a sample ASP.NET web server made with C# 8.0.

## Requirements
- .NET SDK version 8.0
- Docker
- A Linux machine

## .NET
It is necessary to have the `dotnet` installed to build the application
before copying it to the `docker` container.
```bash
sudo snap install dotnet-sdk --classic --channel=8.0
```

## Docker
After having installed the `dotnet` SDK, now it is necessary to get the `docker`
package installed as well.
```bash
sudo apt install docker.io
```

## Running
To start the server, simply execute this script on the terminal.
```bash
./start_web.sh
```