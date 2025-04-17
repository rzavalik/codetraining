# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copia tudo antes de restore
COPY . .

# Faz restore e publish
WORKDIR /src/Calculator.UI
RUN dotnet restore Calculator.UI.csproj
RUN dotnet publish Calculator.UI.csproj -c Release -o /app/publish

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Calculator.UI.dll"]
