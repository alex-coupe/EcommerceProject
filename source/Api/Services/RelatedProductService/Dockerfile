#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Services/RelatedProductService/RelatedProductService.csproj", "Services/RelatedProductService/"]
RUN dotnet restore "Services/RelatedProductService/RelatedProductService.csproj"
COPY . .
WORKDIR "/src/Services/RelatedProductService"
RUN dotnet build "RelatedProductService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RelatedProductService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RelatedProductService.dll"]