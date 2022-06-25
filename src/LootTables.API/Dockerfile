#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/LootTables.API/LootTables.API.csproj", "src/LootTables.API/"]
COPY ["src/LootTables.Application/LootTables.Application.csproj", "src/LootTables.Application/"]
COPY ["src/LootTables.Infrastructure/LootTables.Infrastructure.csproj", "src/LootTables.Infrastructure/"]
COPY ["src/LootTables.Domain/LootTables.Domain.csproj", "src/LootTables.Domain/"]
RUN dotnet restore "src/LootTables.API/LootTables.API.csproj"
COPY . .
WORKDIR "/src/src/LootTables.API"
RUN dotnet build "LootTables.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LootTables.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
LABEL org.opencontainers.image.source https://github.com/krdrag/loot-tables-microservices
ENTRYPOINT ["dotnet", "LootTables.API.dll"]
