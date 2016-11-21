@ECHO OFF
SET /P VERSION_SUFFIX=Please enter version-suffix (can be left empty): 

dotnet "pack" "..\src\CuteAnt.Extensions.Primitives" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Extensions.DependencyInjection.Abstractions" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Extensions.Logging.Abstractions" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Extensions.Logging" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Extensions.Logging.Filter" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Extensions.JsonPatch" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"
dotnet "pack" "..\src\CuteAnt.Text.Encodings.Web" -c "Release" -o "." --version-suffix "%VERSION_SUFFIX%"

pause
