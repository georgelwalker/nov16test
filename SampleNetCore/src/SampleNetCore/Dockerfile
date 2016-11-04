FROM microsoft/dotnet:1.0.0-preview2-sdk
# was :1.0.0-core
RUN mkdir -p /app
COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080
#ENTRYPOINT ["dotnet", "bin/Debug/netcoreapp1.0/SampleNetCore.dll"]
ENTRYPOINT ["dotnet", "run"]
