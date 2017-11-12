@echo off
for /D %%d in (*) do (
    cd %%d  
    cd  
    dotnet restore
    dotnet build
    cd ..
)
exit /b