# -------- build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /.

COPY ./AACalc.Shared/AACalc.Shared.csproj ./AACalc.Shared/
COPY ./AACalc.Domain/AACalc.Domain.csproj ./AACalc.Domain/
COPY ./AACalc.Application/AACalc.Application.csproj ./AACalc.Application/
COPY ./AACalc.Infrastructure/AACalc.Infrastructure.csproj ./AACalc.Infrastructure/
COPY ./AACalc.WebApi/AACalc.WebApi.csproj ./AACalc.WebApi/

RUN dotnet restore ./AACalc.WebApi/AACalc.WebApi.csproj

COPY ./ ./ 
WORKDIR ./AACalc.WebApi
RUN dotnet publish -c Release -o /app/publish

# -------- runtime --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}
EXPOSE 8080
ENTRYPOINT ["dotnet","AACalc.WebApi.dll"]
