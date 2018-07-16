FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PostgreSQLTest/tree/master/PostgreSQLTest.csproj PostgreSQLTest/
RUN dotnet restore PostgreSQLTest/tree/master/PostgreSQLTest/PostgreSQLTest.csproj
COPY . .
WORKDIR /src/PostgreSQLTest
RUN dotnet build PostgreSQLTest/tree/master/PostgreSQLTest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PostgreSQLTest/tree/master/PostgreSQLTest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostgreSQLTest.dll"]
