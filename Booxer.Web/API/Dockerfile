FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Then copy each project
COPY ["Booxer.Web/API/", "Booxer.Web/API/"]
COPY ["Booxer.Infrastructure/", "Booxer.Infrastructure/"]
COPY ["Booxer.Application/", "Booxer.Application/"]
COPY ["Booxer.Domain/", "Booxer.Domain/"]

WORKDIR "/src/Booxer.Web/API"
RUN dotnet restore "Booxer.Web.API.csproj"
RUN dotnet build "Booxer.Web.API.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Booxer.Web.API.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Booxer.Web.API.dll"]