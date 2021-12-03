$numbersFile = Get-Content -Path "input.txt"
$increaseCount = 0;
for($index = 2; $index -lt $numbersFile.length; $index += 1){
    $first = $numbersFile[$index - 2]
    $second = $numbersFile[$index - 1]
    $third = $numbersFile[$index]
    $newMeasurement = ([int]$first + [int]$second + [int]$third)
    if($newMeasurement -gt $currentMeasurement){
        $increaseCount++;
    }
    $currentMeasurement = $newMeasurement
}

Write-Host $increaseCount

