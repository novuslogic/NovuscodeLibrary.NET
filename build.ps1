$module = Get-Module -Name PSNovusTools 

if (-not $module) {
    Write-Error "PSNovusTools module is not installed. Trying to install ... "

    try {
        Install-Module -Name PSNovusTools -Scope CurrentUser -Force -ErrorAction Stop ##-Verbose
    } catch {
        Write-Error "Failed to install PSNovusTools: $_"
        exit 1
    }
} 

Set-VSPackage -ProjectFile "$PWD\Source\NovusCodeLibrary.SimpleTemplate\NovusCodeLibrary.SimpleTemplate.csproj" -Version "0.4.0"

Set-VSPackage -ProjectFile "$PWD\Source\NovusCodeLibrary.JSONUtils\NovusCodeLibrary.JSONUtils.csproj" -Version "0.4.0"

Set-VSPackage -ProjectFile "$PWD\Source\NovusCodeLibrary.Exceptions\NovusCodeLibrary.Exceptions.csproj" -Version "0.4.0" 

Set-VSPackage -ProjectFile "$PWD\Source\NovusCodeLibrary.WebUtils\NovusCodeLibrary.WebUtils.csproj" -Version "0.4.0" 

Set-VSPackage -ProjectFile "$PWD\Source\NovusCodeLibrary.Utils\NovusCodeLibrary.Utils.csproj" -Version "0.4.0"

