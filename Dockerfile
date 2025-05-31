# 1. aşama: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Proje dosyalarını kopyala ve restore yap
COPY ./web-app/*.csproj ./web-app/
COPY ./web-app/*.sln ./web-app/
RUN dotnet restore ./web-app

# Projenin tamamını kopyala ve build et
COPY ./web-app/. ./web-app/
RUN dotnet publish ./web-app -c Release -o /app/publish /p:UseAppHost=false

# 2. aşama: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/publish ./

# Uygulama portunu expose et (örneğin 80)
EXPOSE 80

# Uygulamayı çalıştır
ENTRYPOINT ["dotnet", "web-app.dll"]
