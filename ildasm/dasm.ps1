dotnet publish -c Release --self-contained false --runtime win-x64
if ($?) {
    .\bin\Release\net7.0\win-x64\ildasm.exe .\bin\Release\net7.0\win-x64\ilasm.dll
}