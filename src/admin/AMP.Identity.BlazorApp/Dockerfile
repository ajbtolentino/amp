#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["src/AMP.Identity.BlazorApp/AMP.Identity.BlazorApp.csproj", "src/AMP.Identity.BlazorApp/"]
RUN dotnet restore "src/AMP.Identity.BlazorApp/AMP.Identity.BlazorApp.csproj"
COPY . .
WORKDIR "/src/src/AMP.Identity.BlazorApp"
RUN dotnet build "AMP.Identity.BlazorApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AMP.Identity.BlazorApp.csproj" -c Release -o /app/publish

FROM nginx:1.26.2 AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY --from=build /src/src/AMP.Identity.BlazorApp/nginx.conf /etc/nginx/nginx.conf