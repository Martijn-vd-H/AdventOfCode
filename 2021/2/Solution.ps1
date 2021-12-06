$Position
$Depth

$inputValues = Get-Content "testinput.txt"
foreach($value in $inputValues){
    $value -match "(forward|depth){1}\s(\d+)"
    Write-Host "Match 0" $Matches[0]
    Write-Host "Match 1" $Matches[1]
    Write-Host "Match 2" $Matches[2]
}
