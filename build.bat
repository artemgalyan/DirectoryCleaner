cd Build
del *
cd ../

set trimming="false"
set buildDir="Build"

dotnet publish -c Release --self-contained true /p:PublishSingleFile=true /p:PublishTrimmed=%trimming% -o %buildDir%
pause