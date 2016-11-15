@echo off
REM --certificate-authority="/etc/pki/tls/certs/ca-bundle.trust.crt"
oc login https://192.168.99.100:8443 -u admin --insecure-skip-tls-verify=true -p admin

oc new-project school-bus --description="MOTI School Bus Maintenance" --display-name="School Bus"
oc project school-bus

echo "Setting up database server with a name of app-database"
oc new-app -e POSTGRESQL_USER=test,POSTGRESQL_PASSWORD="test161107",POSTGRESQL_DATABASE=test registry.access.redhat.com/rhscl/postgresql-94-rhel7 --name="app-database"

echo "Setting up a mocking server with a name of mocking-server"
oc new-app https://github.com/GeorgeWalker/nov16test.git --context-dir=/MockingServer --name="mocking-server" --allow-missing-imagestream-tags
oc expose dc/mocking-server --port=8080 --name="mocking-service"
oc expose svc/mocking-service --name="mocking-server"

echo "Setting up a Swagger Editor with a name of swagger-editor"
oc new-app registry.access.redhat.com/rhscl/nodejs-4-rhel7~https://github.com/GeorgeWalker/nov16test.git --context-dir=/Editor --name="swagger-editor-server" --allow-missing-imagestream-tags
oc expose dc/swagger-editor-server --port=8080 --name="swagger-editor-service"
oc expose svc/swagger-editor-service --name="swagger-editor"

echo "Setting up a .NET core application with a name of app-server"
oc new-app registry.access.redhat.com/dotnet/dotnetcore-10-rhel7~https://github.com/GeorgeWalker/nov16test.git --context-dir=/AppServer/src/IO.Swagger --name="app-server" --allow-missing-imagestream-tags
REM oc expose dc/app-server --port=8080 --name="app-server"
oc expose svc/app-server --name="app-server"


	