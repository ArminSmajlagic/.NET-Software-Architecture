#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["services/user/user.api/user.api.csproj", "services/user/user.api/"]
RUN dotnet restore "services/user/user.api/user.api.csproj"
COPY . .
WORKDIR "/src/services/user/user.api"
RUN dotnet build "user.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "user.api.dll"]