$numbersFile = Get-Content -Path "input.txt";

$currentNumber = 9999
$increaseCount = 0
ForEach($number in $numbersFile){
    if($number -gt $currentNumber){
        $increaseCount++
    }

    $currentNumber = $number
}

$solution = $increaseCount + 1; #Why!??
Write-Host $solution