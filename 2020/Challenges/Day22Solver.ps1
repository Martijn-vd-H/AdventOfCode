$input = Get-Content "$PWD\Data\Day22.txt"

$indexP2 = $input.IndexOf("Player 2:");
$p1Deck = $input[1..($indexP2 -2)]
$p2Deck = $input[($indexP2+1)..($input.Length-1)]


while($p1Deck.Length -gt 0 -and $p2Deck.Length -gt 0){
    $p1Card = $p1Deck[0]
    $p2Card = $p2Deck[0]
    $p1Deck[0].Remove();
    $p1Deck[1].Remove();
    if($p1Card -gt $p2Card){
        $p1Deck.Add($p1Card)
        $p1Deck.Add($p2Card)
    } else {
        $p2Deck.Add($p2Card)
        $p2Deck.Add($p1Card)
    }
}

Write-Host $p1Deck
Write-Host $p2Deck
