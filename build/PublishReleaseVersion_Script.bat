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

::cosmos-extensions
dotnet pack src/Cosmos.Extensions.CharMatchers/Cosmos.Extensions.CharMatchers.csproj       -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Enums/Cosmos.Extensions.Enums.csproj                     -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.IdUtils/Cosmos.Extensions.IdUtils.csproj                 -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Joiners/Cosmos.Extensions.Joiners.csproj                 -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Splitters/Cosmos.Extensions.Splitters.csproj             -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Text/Cosmos.Extensions.Text.csproj                       -c Release -o nuget_packages --no-restore

::cosmos-prowess
dotnet pack src/Cosmos.Prowess/Cosmos.Prowess.csproj                                 -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Release" --skip-duplicate
	echo.
)

::get back to build folder
cd build