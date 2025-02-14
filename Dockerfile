# Base image: .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Build image: .NET 8.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SaplingStore.Api/SaplingStore.Api.csproj", "SaplingStore.Api/"]
RUN dotnet restore "SaplingStore.Api/SaplingStore.Api.csproj"
COPY . .
WORKDIR "/src/SaplingStore.Api"
RUN dotnet build "SaplingStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SaplingStore.Api.csproj" -c Release -o /app/publish

# Final stage: Copy files to the base image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SaplingStore.Api.dll"]
