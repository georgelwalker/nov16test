@echo off
echo Running Sonar Tests
copy  /Y project.json project.json.bak
copy  /Y project.sonar.json project.json
dotnet restore
\dev\sonar\SonarQube.Scanner.MSBuild.exe begin /k:"GWTEST" /n:"GWTEST" /v:1.0
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:Rebuild MSBuild.csproj
\dev\sonar\SonarQube.Scanner.MSBuild.exe end
start chrome https://sonarqube.com/code/?id=GWTEST
copy /Y project.json.bak project.json
dotnet restore



