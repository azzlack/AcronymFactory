@echo off
echo.
set /P key= Enter NuGet API Key:
echo.
echo Updating NuGet
nuget.exe update -self
echo.
echo Publishing Packages
nuget push AcronymFactory.1.0.0.nupkg -ApiKey %key%