FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CollectorFake/CollectorFake.csproj", "CollectorFake/"]
COPY ["Security/Security.csproj", "Security/"]
RUN dotnet restore "CollectorFake/CollectorFake.csproj"
COPY . ./
WORKDIR "/src/CollectorFake"
RUN dotnet build "CollectorFake.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CollectorFake.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CollectorFake.dll"]