function GetReport($filePath){
    $xIndex = 0
    $yIndex = 0
    $list = New-Object Collections.Generic.List[Int]
    Get-Content $filePath | ForEach-Object { 
        $xIndex = 0
        [char[]] $_ | ForEach-Object { 
        if($_ -eq '1'){
            if([int]$xIndex -cge $list.Count)
            {
                $list[$xIndex] = 1
            }
            $list[$xIndex]++
        }
        $xIndex++
     } 
     $yIndex++
    }
     $threshold = $yIndex / 2
     $gamma
     $epsilon
     foreach($value in $list){
         if($value -gt $threshold){
            $gamma += "1"
            $epsilon += "0"
         }
         else {
            $gamma += "0"
            $epsilon += "1"
         }
     }
}

function Test {
    $solution = GetReport -File '.\testinput.txt'
   
    if($solution -eq 198){
        Write-Host "Test succeeded" -ForegroundColor Green
    }
    else{
        Write-Host "Test failed. Output was $solution" -ForegroundColor Red
    }
}

Test