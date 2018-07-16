FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PostGreWoring/blob/master/PostgreSQLTest.csproj PostgreSQLTest/
RUN dotnet restore PostGreWoring/blob/master/PostgreSQLTest/PostgreSQLTest.csproj
COPY . .
WORKDIR /src/PostgreSQLTest
RUN dotnet build PostGreWoring/blob/master/PostgreSQLTest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PostGreWoring/blob/master/PostgreSQLTest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostgreSQLTest.dll"]
