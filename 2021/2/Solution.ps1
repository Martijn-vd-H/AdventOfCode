$position = 0
$depth = 0

$inputValues = Get-Content "input.txt"
$regexPattern = "(forward|down|up){1}\s(\d+)"
foreach($value in $inputValues){
    $value -match $regexPattern
    $direction = $Matches[1]
    $distance = $Matches[2]
    if($direction -eq "forward"){
        $position += $distance
    }
    if($direction -eq "up"){
        $depth -= $distance
    }
    if ($direction -eq "down"){
        $depth += $distance
    }
}

Write-Host "The final position is" $position "and the final depth is" $depth
Write-Host "The solution is " ($depth * $position)
