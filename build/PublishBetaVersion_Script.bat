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
dotnet pack src/Cosmos.Extensions.CharMatchers/Cosmos.Extensions.CharMatchers._build.csproj -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.IdUtils/Cosmos.Extensions.IdUtils._build.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Joiners/Cosmos.Extensions.Joiners._build.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Splitters/Cosmos.Extensions.Splitters._build.csproj       -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Text/Cosmos.Extensions.Text._build.csproj                 -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Validations/Cosmos.Extensions.Validations._build.csproj   -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Prowess/Cosmos.Prowess._build.csproj                                 -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Beta" --skip-duplicate
	echo.
)

::get back to build folder
cd build