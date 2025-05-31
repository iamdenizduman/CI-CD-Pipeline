# Base image - build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Proje dosyalarını kopyala ve restore et
COPY web-app/web-app.csproj web-app/
RUN dotnet restore web-app/web-app.csproj

# Tüm kaynak kodunu kopyala
COPY web-app/. web-app/

# Publish (release modunda)
RUN dotnet publish web-app/web-app.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Uygulamayı başlat
ENTRYPOINT ["dotnet", "web-app.dll"]
