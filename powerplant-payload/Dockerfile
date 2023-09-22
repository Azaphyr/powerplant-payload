#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8888
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["powerplant-payload/powerplant-payload.csproj", "powerplant-payload/"]
RUN dotnet restore "powerplant-payload/powerplant-payload.csproj"
COPY . .
WORKDIR "/src/powerplant-payload"
RUN dotnet build "powerplant-payload.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "powerplant-payload.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "powerplant-payload.dll"]