#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TCC.Services.Cart.Rest/TCC.Services.Cart.Rest.csproj", "TCC.Services.Cart.Rest/"]
RUN dotnet restore "TCC.Services.Cart.Rest/TCC.Services.Cart.Rest.csproj"
COPY . .
WORKDIR "/src/TCC.Services.Cart.Rest"
RUN dotnet build "TCC.Services.Cart.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.Services.Cart.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.Services.Cart.Rest.dll"]