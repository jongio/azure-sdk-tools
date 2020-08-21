param(
  [Parameter(Mandatory = $true)]
  $PRDataArtifactPath
)

$PRObjs = [System.Collections.ArrayList]::new()

function Get-PRDataFromFile()
{
    $PRData = Get-Content $PRDataArtifactPath
    foreach ($line in $PRData)
    {
        $PRDetails = $line.Split(';')
        $PRDataObj = [PSCustomObject]@{
            RepoOwner = $PRDetails[0]
            RepoName = $PRDetails[1]
            PRNumber = $PRDetails[2]
        }
        Write-Output ($PRDataObj | Format-Table | Out-String)
        [void]$PRObjs.Add($PRDataObj)
    }
}

Get-PRDataFromFile

