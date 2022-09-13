FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NSE.Catalogo/NSE.Catalogo.csproj", "NSE.Catalogo/"]
RUN dotnet restore "src/NSE.Catalogo/NSE.Catalogo.csproj"
COPY . .
WORKDIR "/src/NSE.Catalogo"
RUN dotnet build "NSE.Catalogo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Catalogo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Catalogo.dll"]
