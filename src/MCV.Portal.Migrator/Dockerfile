#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MCV.Portal.Migrator/MCV.Portal.Migrator.csproj", "src/MCV.Portal.Migrator/"]
COPY ["src/MCV.Portal.EntityFrameworkCore/MCV.Portal.EntityFrameworkCore.csproj", "src/MCV.Portal.EntityFrameworkCore/"]
COPY ["src/MCV.Portal.Core/MCV.Portal.Core.csproj", "src/MCV.Portal.Core/"]
COPY ["src/MCV.Portal.Core.Shared/MCV.Portal.Core.Shared.csproj", "src/MCV.Portal.Core.Shared/"]
RUN dotnet restore "src/MCV.Portal.Migrator/MCV.Portal.Migrator.csproj"
COPY . .
WORKDIR "/src/src/MCV.Portal.Migrator"
RUN dotnet build "MCV.Portal.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MCV.Portal.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCV.Portal.Migrator.dll"]
