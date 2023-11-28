dotnet run --property WarningLevel=0

if ($?) {
    ilasm program.il /output=program.exe
}