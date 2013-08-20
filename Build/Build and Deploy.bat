nuget pack ..\LocalDbApi\LocalDbApi.csproj -Prop Configuration=Release
nuget push LocalDbApi.1.0.0.*.nupkg
move LocalDbApi.1.0.0.*.nupkg Archive