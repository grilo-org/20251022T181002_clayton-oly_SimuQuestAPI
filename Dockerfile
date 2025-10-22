# ================================
# Build stage
# ================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diret�rio de trabalho dentro do container
WORKDIR /src

# Copia a solu��o e os projetos
COPY SimuQuestAPI.sln ./
COPY SimuQuestAPI/*.csproj ./SimuQuestAPI/

# Restaura depend�ncias
RUN dotnet restore

# Copia todo o c�digo do projeto
COPY SimuQuestAPI/. ./SimuQuestAPI/

# Build em Release
WORKDIR /src/SimuQuestAPI
RUN dotnet build -c Release -o /app/build

# ================================
# Publish stage
# ================================
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# ================================
# Runtime stage
# ================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# Expondo a porta padr�o
EXPOSE 5000

# Comando para rodar a aplica��o
ENTRYPOINT ["dotnet", "SimuQuestAPI.dll"]
