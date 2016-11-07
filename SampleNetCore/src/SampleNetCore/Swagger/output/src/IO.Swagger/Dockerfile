FROM microsoft/dotnet:1.0.0-preview2-sdk

ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /app/IO.Swagger
COPY . /app/IO.Swagger
WORKDIR /app/IO.Swagger

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080

RUN ["dotnet", "restore"]
ENTRYPOINT ["dotnet", "run", "-p", "project.json", "web"]
