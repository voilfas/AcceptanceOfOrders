FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["tests/OrderService.Domain.Tests/OrderService.Domain.Tests.csproj", "tests/OrderService.Domain.Tests/"]
COPY ["src/OrderService.Domain/OrderService.Domain.csproj", "src/OrderService.Domain/"]
RUN dotnet restore "tests/OrderService.Domain.Tests/OrderService.Domain.Tests.csproj"
COPY . .
WORKDIR "/src/tests/OrderService.Domain.Tests"
RUN dotnet build "./OrderService.Domain.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OrderService.Domain.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderService.Domain.Tests.dll"]
