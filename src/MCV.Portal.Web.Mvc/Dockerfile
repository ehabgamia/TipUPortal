#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/MCV.Portal.Web.Mvc/MCV.Portal.Web.Mvc.csproj", "src/MCV.Portal.Web.Mvc/"]
COPY ["src/MCV.Portal.Web.Core/MCV.Portal.Web.Core.csproj", "src/MCV.Portal.Web.Core/"]
COPY ["src/MCV.Portal.Application/MCV.Portal.Application.csproj", "src/MCV.Portal.Application/"]
COPY ["src/MCV.Portal.Application.Shared/MCV.Portal.Application.Shared.csproj", "src/MCV.Portal.Application.Shared/"]
COPY ["src/MCV.Portal.Core.Shared/MCV.Portal.Core.Shared.csproj", "src/MCV.Portal.Core.Shared/"]
COPY ["src/MCV.Portal.Core/MCV.Portal.Core.csproj", "src/MCV.Portal.Core/"]
COPY ["src/MCV.Portal.EntityFrameworkCore/MCV.Portal.EntityFrameworkCore.csproj", "src/MCV.Portal.EntityFrameworkCore/"]
COPY ["src/MCV.Portal.GraphQL/MCV.Portal.GraphQL.csproj", "src/MCV.Portal.GraphQL/"]
RUN dotnet restore "src/MCV.Portal.Web.Mvc/MCV.Portal.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/MCV.Portal.Web.Mvc"
RUN dotnet build "MCV.Portal.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MCV.Portal.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCV.Portal.Web.Mvc.dll"]
