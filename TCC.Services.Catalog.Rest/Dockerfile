#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TCC.Services.Catalog.Rest/TCC.Services.Catalog.Rest.csproj", "TCC.Services.Catalog.Rest/"]
RUN dotnet restore "TCC.Services.Catalog.Rest/TCC.Services.Catalog.Rest.csproj"
COPY . .
WORKDIR "/src/TCC.Services.Catalog.Rest"
RUN dotnet build "TCC.Services.Catalog.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.Services.Catalog.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.Services.Catalog.Rest.dll"]