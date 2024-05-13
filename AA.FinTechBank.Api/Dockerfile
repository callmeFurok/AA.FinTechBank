#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 7224
EXPOSE 5294

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AA.FinTechBank.Api/AA.FinTechBank.Api.csproj", "AA.FinTechBank.Api/"]
COPY ["AA.FinTechBank.Application/AA.FinTechBank.Application.csproj", "AA.FinTechBank.Application/"]
COPY ["AA.FinTechBank.Common/AA.FinTechBank.Common.csproj", "AA.FinTechBank.Common/"]
COPY ["AA.FinTechBank.Domain/AA.FinTechBank.Domain.csproj", "AA.FinTechBank.Domain/"]
COPY ["AA.FinTechBank.Infrastructure/AA.FinTechBank.Infrastructure.csproj", "AA.FinTechBank.Infrastructure/"]
RUN dotnet restore "./AA.FinTechBank.Api/./AA.FinTechBank.Api.csproj"
COPY . .
WORKDIR "/src/AA.FinTechBank.Api"
RUN dotnet build "./AA.FinTechBank.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AA.FinTechBank.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AA.FinTechBank.Api.dll"]