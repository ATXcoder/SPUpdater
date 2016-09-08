param(
    [Microsoft.PowerShell.ExecutionPolicy]$policy
)

$obj = [PSCustomObject]@{
"CurrentPolicy" = (Get-ExecutionPolicy).ToString();
"NewPolicy" = ""
}

#Update policy
Set-ExecutionPolicy -Scope Process -ExecutionPolicy $policy -Force
$obj.NewPolicy = (Get-ExecutionPolicy).ToString()

$obj
