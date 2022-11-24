FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/orders/orders.api/orders.api.csproj", "services/orders/orders.api/"]
COPY ["services/orders/orders.appliaction/orders.appliaction.csproj", "services/orders/orders.appliaction/"]
COPY ["services/orders/orders.domain/orders.domain.csproj", "services/orders/orders.domain/"]
COPY ["RabbitMQ.Events/EventBus.Messages/EventBus.Messages.csproj", "RabbitMQ.Events/EventBus.Messages/"]
COPY ["services/orders/orders.infrastructure/orders.infrastructure.csproj", "services/orders/orders.infrastructure/"]
RUN dotnet restore "services/orders/orders.api/orders.api.csproj"
COPY . .
WORKDIR "/src/services/orders/orders.api"
RUN dotnet build "orders.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "orders.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "orders.api.dll"]



