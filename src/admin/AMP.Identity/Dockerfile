FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app

EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["admin/AMP.Identity/AMP.Identity.csproj", "src/AMP.Identity/"]
COPY ["admin/AMP.Identity.BlazorApp/AMP.Identity.BlazorApp.csproj", "src/AMP.Identity.BlazorApp/"]
RUN dotnet restore "src/AMP.Identity/AMP.Identity.csproj"
COPY . .
WORKDIR "/src/admin/AMP.Identity"
RUN dotnet build "AMP.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AMP.Identity.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AMP.Identity.dll"]