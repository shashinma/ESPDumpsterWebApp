FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ESPDumpsterWebApp/ESPDumpsterWebApp.csproj", "ESPDumpsterWebApp/ESPDumpsterWebApp.csproj"]
COPY ["ESPDumpsterWebApp.API/", "ESPDumpsterWebApp.API/"]
RUN dotnet restore "ESPDumpsterWebApp/ESPDumpsterWebApp.csproj"

COPY . .
WORKDIR "/src"
RUN dotnet build "ESPDumpsterWebApp/ESPDumpsterWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ESPDumpsterWebApp/ESPDumpsterWebApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "ESPDumpsterWebApp.dll"]