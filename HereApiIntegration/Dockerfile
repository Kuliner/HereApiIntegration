FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["HereApiIntegration/HereApiIntegration.csproj", "HereApiIntegration/"]
RUN dotnet restore "HereApiIntegration/HereApiIntegration.csproj"
COPY . .
WORKDIR "/src/HereApiIntegration"
RUN dotnet build "HereApiIntegration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HereApiIntegration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HereApiIntegration.dll"]