FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ./PostgreSQLTest/PostgreSQLTest.csproj .
RUN dotnet restore 
COPY . .
WORKDIR /src
RUN dotnet build PostgreSQLTest.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PostgreSQLTest.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PostgreSQLTest.dll"]