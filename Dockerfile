# Etapa base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiando toda a pasta app para o container
COPY app/ ./app/

# Restaura os pacotes
RUN dotnet restore ./app/OrcamentoEletrico.sln

# Publica o app
FROM build AS publish
RUN dotnet publish ./app/OrcamentoEletrico/OrcamentoEletrico.csproj -c Release -o /app/publish

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrcamentoEletrico.dll"]
