REM builds the docker image with the repository and tag used in this example

REM docker build -f ../Consumer/Dockerfile -t consumer:latest ../
docker build -f ../Producer/Dockerfile -t producer:latest ../

set /p DUMMY=Hit ENTER to continue...