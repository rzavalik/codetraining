# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copia apenas o csproj e faz restore
COPY ./Calculator.API/Calculator.API.csproj Calculator.API/
RUN dotnet restore Calculator.API/Calculator.API.csproj

# Copia o restante do código
COPY . .

WORKDIR /src/Calculator.API
RUN dotnet publish Calculator.API.csproj -c Release -o /app/publish

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Calculator.API.dll"]
