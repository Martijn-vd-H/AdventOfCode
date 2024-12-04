var safeCount = 0;

foreach(var line in System.IO.File.ReadAllLines("TestInput1")){
    var numbers = line.Split(' ').Select(a=>Convert.ToInt32(a)).ToArray();
    bool? isIncrease = null;
    for(int i = 0; i < numbers.Length - 1; i++)
    {
        var dist = numbers[i] - numbers[i + 1];
        if(isIncrease == null){
            isIncrease = dist > 0;
        }
        else if(isIncrease && dist < 0){
            goto Skip;
        }
        else if(!isIncrease && dist > 0){
            goto Skip;
        }
    }

    Skip:
        continue;
}