# Base image: .NET 8.0 runtime (production)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image: .NET 8.0 SDK (development)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Projeyi kopyala
COPY ./SaplingStore.csproj ./   

# Bağımlılıkları yükle
RUN dotnet restore "./SaplingStore.csproj"

# Tüm kaynakları kopyala
COPY . .  

# Build işlemi
RUN dotnet build "SaplingStore.csproj" -c Release -o /app/build

# Uygulamayı yayınla
FROM build AS publish
RUN dotnet publish "SaplingStore.csproj" -c Release -o /app/publish

# Final stage: Uygulamayı temel imaja kopyala
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 

# Çalıştırma komutu
ENTRYPOINT ["dotnet", "SaplingStore.dll"]
