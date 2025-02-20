# Use the official .NET image as a base image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

# Copy the .csproj file and restore any dependencies (via NuGet)
COPY . .
RUN dotnet publish backend/modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj -c Release -o ./publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/publish .
EXPOSE 5002
ENTRYPOINT ["dotnet", "Nexus.Auth.Api.dll"]