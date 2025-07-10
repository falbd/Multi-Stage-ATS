# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and restore
COPY ["Multi-Stage-ATS.sln", "./"]
COPY ["Multi-Stage-ATS.csproj", "./"]  # needed so restore can locate it under the solution
RUN dotnet restore "Multi-Stage-ATS.sln"

# Copy everything else and build
COPY . .
RUN dotnet build "Multi-Stage-ATS.sln" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Multi-Stage-ATS.sln" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Multi-Stage-ATS.dll"]


