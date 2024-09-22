#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["src/TheIdServer/TheIdServer.csproj", "src/TheIdServer/"]
COPY ["src/TheIdServer.BlazorApp/TheIdServer.BlazorApp.csproj", "src/TheIdServer.BlazorApp/"]
RUN dotnet restore "src/TheIdServer/TheIdServer.csproj"
COPY . .
WORKDIR "/src/src/TheIdServer"
RUN dotnet build "TheIdServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheIdServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheIdServer.dll"]