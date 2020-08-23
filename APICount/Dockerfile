FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
WORKDIR /app

# copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# application build
COPY . ./
RUN dotnet publish -c Release -o out

# image build
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "APICount.dll"]