
$modulePath = "D:\Projects\PSNovusTools\PSNovusTools"
Import-Module -Name $modulePath -Force

Set-VSPackage -ProjectFile "D:\Projects\NovuscodeLibrary.NET\Source\NovusCodeLibrary.SimpleTemplate\NovusCodeLibrary.SimpleTemplate.csproj" -Version "0.3.0"

Set-VSPackage -ProjectFile "D:\Projects\NovuscodeLibrary.NET\Source\NovusCodeLibrary.JSONUtils\NovusCodeLibrary.JSONUtils.csproj" -Version "0.3.0"

Set-VSPackage -ProjectFile "D:\Projects\NovuscodeLibrary.NET\Source\NovusCodeLibrary.Exceptions\NovusCodeLibrary.Exceptions.csproj" -Version "0.3.0" 

Set-VSPackage -ProjectFile "D:\Projects\NovuscodeLibrary.NET\Source\NovusCodeLibrary.WebUtils\NovusCodeLibrary.WebUtils.csproj" -Version "0.3.0" 

Set-VSPackage -ProjectFile "D:\Projects\NovuscodeLibrary.NET\Source\NovusCodeLibrary.Utils\NovusCodeLibrary.Utils.csproj" -Version "0.3.0"

