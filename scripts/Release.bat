@echo off

echo =======================================================================
echo CosmosStack.Prowess
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
dotnet pack src/CosmosStack.Extensions.CharMatchers        -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Enums.Enhanced      -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.IdUtils             -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Joiners             -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Reflection.Enhanced -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Splitters           -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Text                -c Release -o nuget_packages --no-restore

::CosmosStack-prowess
dotnet pack src/CosmosStack.Prowess                        -c Release -o nuget_packages --no-restore

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
cd scripts