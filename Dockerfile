# Etapa base para runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos os .csproj
COPY OrcamentoEletrico/OrcamentoEletrico.csproj OrcamentoEletrico/
COPY OrcamentoEletrico/OrcamentoEletricoApp/OrcamentoEletricoApp.csproj OrcamentoEletrico/OrcamentoEletricoApp/
COPY OrcamentoEletrico/OrcamentoEletricoDomain/OrcamentoEletricoDomain.csproj OrcamentoEletrico/OrcamentoEletricoDomain/
COPY OrcamentoEletrico/OrcamentoEletricoInfra/OrcamentoEletricoInfra.csproj OrcamentoEletrico/OrcamentoEletricoInfra/
COPY OrcamentoEletrico/OrcamentoEletricoTest/OrcamentoEletricoTest.csproj OrcamentoEletrico/OrcamentoEletricoTest/

# Restaura os pacotes
RUN dotnet restore "OrcamentoEletrico/OrcamentoEletrico.csproj"

# Copia tudo e compila
COPY . .
WORKDIR "/src/OrcamentoEletrico"
RUN dotnet build "OrcamentoEletrico.csproj" -c Release -o /app/build

# Publica o app
FROM build AS publish
RUN dotnet publish "OrcamentoEletrico.csproj" -c Release -o /app/publish

# Imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrcamentoEletrico.dll"]
