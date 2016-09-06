$obj = [PSCustomObject]@{
"Powershell_Version" = $PSVersionTable.PSVersion
"OS_Version" = (Get-WmiObject win32_operatingsystem).caption
"Computer_Name" = (Get-WmiObject win32_operatingsystem).PSComputerName
}

$obj