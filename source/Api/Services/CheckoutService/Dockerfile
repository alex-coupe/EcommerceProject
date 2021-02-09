#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/CheckoutService/CheckoutService/CheckoutService.csproj", "Services/CheckoutService/CheckoutService/"]
RUN dotnet restore "Services/CheckoutService/CheckoutService/CheckoutService.csproj"
COPY . .
WORKDIR "/src/Services/CheckoutService/CheckoutService"
RUN dotnet build "CheckoutService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckoutService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckoutService.dll"]