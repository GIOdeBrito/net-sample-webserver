# Dotnet 8 project build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Restore project
COPY *.csproj ./
RUN dotnet restore

# Copy and build project
COPY . ./
RUN dotnet build csharp-web.csproj -c Release

# Use the official ASP.NET Core runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

COPY --from=build /app/bin/Release/net8.0/ .

COPY --from=build /app/wwwroot ./wwwroot

EXPOSE 80

# Command to run the application when the container starts
ENTRYPOINT ["dotnet", "csharp-web.dll"]