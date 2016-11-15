SonarQube.Scanner.MSBuild.exe begin /k:"sonarqube_project_key" /n:"sonarqube_project_name" /v:"sonarqube_project_version"
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /t:Rebuild
SonarQube.Scanner.MSBuild.exe end