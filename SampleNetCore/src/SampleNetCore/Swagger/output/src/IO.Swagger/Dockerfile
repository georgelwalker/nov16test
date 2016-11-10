FROM registry.access.redhat.com/dotnet/dotnetcore-10-rhel7/dotnet/dotnetcore-10-rhel7 
#FROM dotnet/dotnetcore-10-rhel7 

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
