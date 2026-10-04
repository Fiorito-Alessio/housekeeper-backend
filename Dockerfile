FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["src/HouseKeeper.Api/HouseKeeper.Api.csproj", "src/HouseKeeper.Api/"]
COPY ["src/HouseKeeper.Application/HouseKeeper.Application.csproj", "src/HouseKeeper.Application/"]
COPY ["src/HouseKeeper.Domain/HouseKeeper.Domain.csproj", "src/HouseKeeper.Domain/"]
COPY ["src/HouseKeeper.Infrastructure/HouseKeeper.Infrastructure.csproj", "src/HouseKeeper.Infrastructure/"]

COPY [".editorconfig", ".editorconfig"]
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["global.json", "global.json"]

RUN dotnet restore "src/HouseKeeper.Api/HouseKeeper.Api.csproj"

COPY . .

RUN dotnet publish "src/HouseKeeper.Api/HouseKeeper.Api.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

USER $APP_UID
EXPOSE 8080

ENTRYPOINT ["dotnet", "HouseKeeper.Api.dll"]