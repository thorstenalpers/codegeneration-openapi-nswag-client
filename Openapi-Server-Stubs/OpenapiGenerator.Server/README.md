# OpenapiGenerator.Server - ASP.NET Core 3.1 Server

This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.

## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```
## Run in Docker

```
cd ..//OpenapiGenerator.Server
docker build -t openapigenerator.server .
docker run -p 5000:8080 openapigenerator.server
```