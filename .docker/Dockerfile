# Use the official .NET image with SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/*.csproj .
RUN dotnet restore *.csproj

# Copy everything else and build
COPY src/. .

# Command to run the application with dotnet watch
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://*:5181"]
