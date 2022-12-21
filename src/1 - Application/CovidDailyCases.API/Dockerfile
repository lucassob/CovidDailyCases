FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/1 - Application/CovidDailyCases.API/CovidDailyCases.API.csproj", "CovidDailyCases.API/"]
RUN dotnet restore "src/CovidDailyCases.API/CovidDailyCases.API.csproj"
COPY . .
WORKDIR "/src/1 - Application/CovidDailyCases.API"
RUN dotnet build "CovidDailyCases.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CovidDailyCases.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CovidDailyCases.API.dll"]
