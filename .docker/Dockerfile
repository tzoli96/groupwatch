# Use the official .NET image with SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Install dotnet-ef tool
RUN dotnet tool install --global dotnet-ef

# Install PostgreSQL client tools
RUN apt-get update \
    && apt-get install -y postgresql-client \
    && rm -rf /var/lib/apt/lists/*

# Set the PATH for the dotnet tools
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy csproj and restore as distinct layers
COPY src/*.csproj .
RUN dotnet restore *.csproj

# Copy everything else and build
COPY src/. .

# Expose port 80
EXPOSE 80

# Copy the entrypoint script
COPY .docker/entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh

# Set the entrypoint
ENTRYPOINT ["/entrypoint.sh"]
