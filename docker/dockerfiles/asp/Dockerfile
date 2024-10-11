FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["ASP.NET.csproj", "./"]
RUN dotnet restore "ASP.NET.csproj"
COPY . .
RUN dotnet new tool-manifest --force
RUN dotnet tool install --local dotnet-ef --version 8.0.8
RUN dotnet dotnet-ef database update
WORKDIR "/src/."
RUN dotnet build "ASP.NET.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "ASP.NET.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASP.NET.dll"]
