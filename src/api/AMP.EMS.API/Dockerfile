FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:1234

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/api/AMP.EMS.API/AMP.EMS.API.csproj", "src/api/AMP.EMS.API/"]
RUN dotnet restore "src/api/AMP.EMS.API/AMP.EMS.API.csproj"
COPY . .
WORKDIR "/src/src/api/AMP.EMS.API"
RUN dotnet build "AMP.EMS.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "AMP.EMS.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AMP.EMS.API.dll"]
