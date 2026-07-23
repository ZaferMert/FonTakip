FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the csproj and restore dependencies
COPY ["FonTakip.API.csproj", "./"]
RUN dotnet restore "FonTakip.API.csproj"

# Copy the rest of the files and build
COPY . .
RUN dotnet publish "FonTakip.API.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5043

# Set the URL to match the local development port
ENV ASPNETCORE_URLS=http://+:5043

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "FonTakip.API.dll"]
