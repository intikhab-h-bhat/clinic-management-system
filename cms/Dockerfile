# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution file
COPY *.sln .

# Copy all project files
COPY Api.Dev.Middleware.Domain/ Api.Dev.Middleware.Domain/
COPY Api.Dev.Middleware.Application/ Api.Dev.Middleware.Application/
COPY Api.Dev.Middleware.Infrastructure/ Api.Dev.Middleware.Infrastructure/
COPY Api.Dev.Middleware/ Api.Dev.Middleware/

# Restore
WORKDIR /src/Api.Dev.Middleware
RUN dotnet restore "Api.Dev.Middleware.Ui.csproj"

# Build
RUN dotnet build "Api.Dev.Middleware.Ui.csproj" -c Release -o /app/build

# Publish
RUN dotnet publish "Api.Dev.Middleware.Ui.csproj" -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

EXPOSE 5022

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://+:5022

COPY --from=build /app/publish .




ENTRYPOINT ["dotnet", "Api.Dev.Middleware.Ui.dll"]
