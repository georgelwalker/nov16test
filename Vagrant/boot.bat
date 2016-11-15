REM set the environment.
docker-machine restart openshift
docker-machine env openshift > environment.bat
CALL environment.bat
oc cluster up