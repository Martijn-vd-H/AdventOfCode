function Solve($InputContent) {
    $position = 0
    $depth = 0
    $aim = 0
    
    $regexPattern = "(forward|down|up){1}\s(\d+)"
   
    foreach ($value in $InputContent) {
        $value -match $regexPattern | Out-Null
        $direction = $Matches[1]
        $amount = $Matches[2]
        if ($direction -eq "forward") {
            $position += $amount
            if($amount -gt 0 -and $aim -gt 0){
                $depth += $aim * $amount
            }
        }
        if ($direction -eq "up") {
            $aim -= $amount
        }
        if ($direction -eq "down") {
            $aim += $amount
        }
    }

    return ($position * $depth)

}

function Test {
    $testInput = Get-Content '.\testinput.txt'
    $result = Solve -InputContent $testInput
    if (900 -eq $result) {
        Write-Host "Test Succeeded" -ForegroundColor Green
    }
    else {
        throw "Test failed, expected 900 but was $result"
    }
}

Test

$inputFile = Get-Content '.\input.txt'
$answer = Solve -InputContent $inputFile
Write-Host "Answer is: $answer" -ForegroundColor Yellow