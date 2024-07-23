#!/bin/bash
set -e

# Wait until PostgreSQL is ready
until pg_isready -h db -U myuser; do
  >&2 echo "Postgres is unavailable - sleeping"
  sleep 1
done

# Run migrations
dotnet ef database update

# Run the application
exec dotnet watch run --urls http://*:80
