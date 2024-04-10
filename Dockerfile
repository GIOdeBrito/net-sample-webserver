# Use the official ASP.NET Core runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Copy published files to the container
COPY bin/Release/net8.0/ .

# Copy the wwwroot folder
COPY wwwroot /app/wwwroot

# Command to run the application when the container starts
ENTRYPOINT ["dotnet", "csharp-web.dll"]