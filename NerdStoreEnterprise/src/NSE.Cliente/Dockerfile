FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/NSE.Cliente/NSE.Cliente.csproj", "NSE.Cliente/"]
RUN dotnet restore "src/NSE.Cliente/NSE.Cliente.csproj"
COPY . .
WORKDIR "/src/NSE.Cliente"
RUN dotnet build "NSE.Cliente.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Cliente.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Cliente.dll"]
