function calculate(input)
{
    let excursionPrice = Number(input[0]);
    let puzzles = Number(input[1]);
    let dolls = Number(input[2]);
    let bears = Number(input[3]);
    let minions = Number(input[4]);
    let trucs = Number(input[5]);

    let sum = (puzzles * 2.60) + (dolls * 3) + (bears * 4.10) + (minions * 8.20) + (trucs * 2);
     sum = sum * 0.9;
    let totalCount = puzzles + dolls + bears + minions + trucs;
    if(totalCount >= 50)
    {
        sum = sum * 0.75;
    }

    if(sum >= excursionPrice)
    {
        console.log(`Yes! ${(sum - excursionPrice).toFixed(2)} lv left.`);
    }
    else
    {
        console.log(`Not enough money! ${(excursionPrice - sum).toFixed(2)} lv needed.`);
    }
}

calculate((["40.8",
    "20",
    "25",
    "30",
    "50",
    "10"]));