FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PostGreWoring/tree/master/PostgreSQLTest.csproj PostgreSQLTest/
RUN dotnet restore PostGreWoring/tree/master/PostgreSQLTest/PostgreSQLTest.csproj
COPY . .
WORKDIR /src/PostgreSQLTest
RUN dotnet build PostGreWoring/tree/master/PostgreSQLTest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PostGreWoring/tree/master/PostgreSQLTest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostgreSQLTest.dll"]
