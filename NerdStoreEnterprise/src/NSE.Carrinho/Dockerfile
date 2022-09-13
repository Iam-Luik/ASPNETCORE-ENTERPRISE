FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NSE.Carrinho/NSE.Carrinho.csproj", "NSE.Carrinho/"]
RUN dotnet restore "src/NSE.Carrinho/NSE.Carrinho.csproj"
COPY . .
WORKDIR "/src/NSE.Carrinho"
RUN dotnet build "NSE.Carrinho.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Carrinho.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Carrinho.dll"]
