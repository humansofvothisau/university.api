FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY HOVUni.sln ./
COPY DAOLibrary/*.csproj ./DAOLibrary/
COPY DTOLibrary/*.csproj ./DTOLibrary/
COPY university.api/*.csproj ./university.api/

RUN dotnet restore
COPY . .
WORKDIR /src/DAOLibrary
RUN dotnet build -c Release -o /app

WORKDIR /src/DTOLibrary
RUN dotnet build -c Release -o /app

WORKDIR /src/university.api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# ENTRYPOINT [ "dotnet", "HOVStory.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet university.api.dll