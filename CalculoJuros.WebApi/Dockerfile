#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CalculoJuros.WebApi/CalculoJuros.WebApi.csproj", "CalculoJuros.WebApi/"]
RUN dotnet restore "CalculoJuros.WebApi/CalculoJuros.WebApi.csproj"
COPY . .
WORKDIR "/src/CalculoJuros.WebApi"
RUN dotnet build "CalculoJuros.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoJuros.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoJuros.WebApi.dll"]
