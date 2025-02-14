# Base image: .NET 8.0 runtime (production)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image: .NET 8.0 SDK (development)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sadece .csproj dosyasını kopyala ve restore et
COPY ./SaplingStore.csproj ./
RUN dotnet restore "./SaplingStore.csproj"

# Tüm kaynakları kopyala
COPY . .  
WORKDIR "/src/SaplingStore/SaplingStore"

# Build ve publish adımlarını opsiyonel hale getir
RUN dotnet build "./SaplingStore.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./SaplingStore.csproj" -c Release -o /app/publish

# Final stage: Copy published files to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "SaplingStore.dll"]
