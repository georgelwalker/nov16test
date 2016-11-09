oc login -u admin -p admin

oc new-project school-bus --description="MOTI School Bus Maintenance" --display-name="School Bus"

oc project school-bus

oc new-app https://github.com/GeorgeWalker/nov16test.git --context-dir=/MockingServer --name="mocking-server"