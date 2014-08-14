@echo off
echo.
echo Deleting old packages
del AcronymFactory.*.nupkg
echo.
echo Updating NuGet
nuget.exe update -self
echo Building solution
C:\Windows\Microsoft.Net\Framework64\v4.0.30319\MSBuild.exe ..\src\AcronymFactory.sln /p:Configuration=Release
echo.
echo Creating AcronymFactory Package
nuget pack nuget\AcronymFactory.nuspec -Symbols