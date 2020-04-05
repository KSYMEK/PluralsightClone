FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY . .
RUN dotnet publish src/Pluralsight.APIGateway -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

COPY --from=build /app/out .
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker
ENV NTRADA_CONFIG ntrada.docker
ENTRYPOINT ["dotnet", "Pluralsight.APIGateway.dll"]