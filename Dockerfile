FROM microsoft/dotnet:1.1.4-runtime
WORKDIR /dotnetapp
COPY PiApp/out .
ENTRYPOINT ["dotnet", "PiApp.dll"]
