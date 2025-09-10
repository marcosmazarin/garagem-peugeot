# syntax=docker/dockerfile:1

# Create a stage for building the application.
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /source

# Copia apenas a solution e os csproj primeiro para otimizar cache
COPY *.sln ./
COPY AllGaragem/*.csproj AllGaragem/
COPY AllGaragem.Application/*.csproj AllGaragem.Application/
COPY AllGaragem.Domain/*.csproj AllGaragem.Domain/
COPY AllGaragem.Infrastructure/*.csproj AllGaragem.Infrastructure/
COPY AllGaragem.IoC/*.csproj AllGaragem.IoC/

# Restaura pacotes
RUN dotnet restore

# Agora copia todo o restante do código
COPY . .

# Build e publish
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish AllGaragem/AllGaragem.Api.csproj -c Release -o /app

##########################################
# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final
WORKDIR /app

COPY --from=build /app .

USER $APP_UID

ENTRYPOINT [ "dotnet", "AllGaragem.Api.dll" ]

