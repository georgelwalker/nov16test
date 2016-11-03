FROM microsoft/dotnet:1.0.0-preview2-sdk
# was :1.0.0-core
RUN mkdir -p /app
COPY . /app
WORKDIR /app

RUN dotnet restore
RUN dotnet build

ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
ENTRYPOINT ["dotnet", "SampleNetCore.dll"]

