FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NSE.Pedido/NSE.Pedido.csproj", "NSE.Pedido/"]
RUN dotnet restore "src/NSE.Pedido/NSE.Pedido.csproj"
COPY . .
WORKDIR "/src/NSE.Pedido"
RUN dotnet build "NSE.Pedido.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pedido.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pedido.dll"]
