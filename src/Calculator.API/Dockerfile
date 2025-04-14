# ---- Build Stage ----
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src
COPY *.csproj ./Calculator.API/
RUN dotnet restore ./Calculator.API.csproj
COPY . .
WORKDIR /src/Calculator.API
RUN dotnet publish -c Release -o /app/publish

# ---- Runtime Stage ----
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "Calculator.API.dll"]
