FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["tv.api/tv.api.csproj", "tv.api/"]
RUN dotnet restore "tv.api/tv.api.csproj"
COPY . .
WORKDIR "/src/tv.api"
RUN dotnet build "tv.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tv.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tv.api.dll"]