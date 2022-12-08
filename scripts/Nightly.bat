@echo off

echo =======================================================================
echo Cosmos.Prowess
echo =======================================================================

::go to parent folder
cd ..

::create nuget_packages
if not exist nuget_packages (
    md nuget_packages
    echo Created nuget_packages folder.
)

::clear nuget_packages
for /R "nuget_packages" %%s in (*) do (
    del "%%s"
)
echo Cleaned up all nuget packages.
echo.

::start to package all projects

::CosmosStack-extensions
dotnet pack src/Cosmos.Extensions.Collections.Enhanced -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Enums.Enhanced       -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.IdUtils              -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Reflection.Enhanced  -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Text                 -c Release -o nuget_packages --no-restore

::CosmosStack-prowess
dotnet pack src/Cosmos.Prowess                         -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do (
::    dotnet nuget push "%%s" -s "Nightly" --skip-duplicate --no-symbols
    dotnet nuget push "%%s" -s "Nightly" --skip-duplicate
    echo.
)

::get back to build folder
cd scripts