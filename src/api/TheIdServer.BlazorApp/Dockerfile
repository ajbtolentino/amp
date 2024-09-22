#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["src/TheIdServer.BlazorApp/TheIdServer.BlazorApp.csproj", "src/TheIdServer.BlazorApp/"]
RUN dotnet restore "src/TheIdServer.BlazorApp/TheIdServer.BlazorApp.csproj"
COPY . .
WORKDIR "/src/src/TheIdServer.BlazorApp"
RUN dotnet build "TheIdServer.BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheIdServer.BlazorApp.csproj" -c Release -o /app/publish

FROM nginx:1.26.2 AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY --from=build /src/src/TheIdServer.BlazorApp/nginx.conf /etc/nginx/nginx.conf