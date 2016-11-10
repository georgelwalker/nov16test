FROM dotnet/dotnetcore-10-rhel7 
# https://github.com/dotnet/dotnet-docker/blob/master/1.0.0-preview2/debian/sdk/Dockerfile
# microsoft/dotnet:1.0.0-preview2-sdk

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /app/IO.Swagger
COPY . /app/IO.Swagger
WORKDIR /app/IO.Swagger

RUN dotnet restore
RUN dotnet build

# install or update the database
RUN dotnet ef database update

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "run"]
