FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia tutto il progetto nel container di build
COPY . .

# Pubblica l'applicazione in modalità Release
RUN dotnet publish "BillingService.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copia gli artefatti pubblicati dallo stage di build
COPY --from=build /app/publish .

EXPOSE 80

# Avvia l'applicazione (nome dll = nome progetto)
ENTRYPOINT ["dotnet", "BillingService.dll"]

