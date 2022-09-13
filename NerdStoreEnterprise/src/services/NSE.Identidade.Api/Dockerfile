FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/services/NSE.Identidade.Api/NSE.Identidade.Api.csproj", "NSE.Identidade.Api/"]
RUN dotnet restore "src/services/NSE.Identidade.Api/NSE.Identidade.Api.csproj"
COPY . .
WORKDIR "/src/NSE.Identidade.Api"
RUN dotnet build "NSE.Identidade.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NSE.Identidade.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NSE.Identidade.Api.dll"]
