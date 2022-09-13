FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NSE.Pagamento/NSE.Pagamento.csproj", "NSE.Pagamento/"]
RUN dotnet restore "src/NSE.Pagamento/NSE.Pagamento.csproj"
COPY . .
WORKDIR "/src/NSE.Pagamento"
RUN dotnet build "NSE.Pagamento.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Pagamento.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Pagamento.dll"]
