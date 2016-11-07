set executable=.\bin\swagger-codegen-cli.jar

REM set JAVA_OPTS=%JAVA_OPTS% -Xmx1024M
set ags=generate -i sample.json -l aspnetcore -o output

java %JAVA_OPTS% -jar %executable% %ags%