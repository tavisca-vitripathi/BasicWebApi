FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
COPY webapi/bin/Debug/netcoreapp2.1/publish .
EXPOSE 5876
WORKDIR .
ENTRYPOINT ["dotnet", "webapi.dll","--url=https://*:5876"]
