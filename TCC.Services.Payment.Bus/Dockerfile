#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TCC.Services.Payment.Bus/TCC.Services.Payment.Bus.csproj", "TCC.Services.Payment.Bus/"]
RUN dotnet restore "TCC.Services.Payment.Bus/TCC.Services.Payment.Bus.csproj"
COPY . .
WORKDIR "/src/TCC.Services.Payment.Bus"
RUN dotnet build "TCC.Services.Payment.Bus.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TCC.Services.Payment.Bus.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TCC.Services.Payment.Bus.dll"]