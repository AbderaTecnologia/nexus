# Use the official .NET image as a base image
FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:9b0a4330cb3dac23ebd6df76ab4211ec5903907ad2c1ccde16a010bf25f8dfde AS build-env
WORKDIR /app

# Copy the .csproj file and restore any dependencies (via NuGet)
COPY . .
RUN dotnet publish backend/modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj -c Release -o ./publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:c3aee4ea4f51369d1f906b4dbd19b0f74fd34399e5ef59f91b70fcd332f36566
WORKDIR /app
COPY --from=build-env /app/publish .
EXPOSE 5002
ENTRYPOINT ["dotnet", "Nexus.Auth.Api.dll"]