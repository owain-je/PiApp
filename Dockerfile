FROM microsoft/dotnet:runtime
WORKDIR /dotnetapp
COPY PiApp/out .
ENTRYPOINT ["dotnet", "PiApp.dll"]