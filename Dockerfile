#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./src/SportEvents.csproj", "."]
COPY ["./SportEvents.Test/SportEvents.Test.csproj", "/SportEvents.Test/"]
COPY ["./src/bin/Debug/net5.0/appsettings.Production.json", "."]
RUN dotnet restore 
COPY . .
WORKDIR "/src/."
RUN dotnet build "SportEvents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SportEvents.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SportEvents.dll"]