function calculate(input)
{
    let budget = Number(input[0]);
    let videoCards = Number(input[1]);
    let processors = Number(input[2]);
    let ram = Number(input[3]);

    let videoCardsSum = (videoCards * 250);
    let processorsSum = videoCardsSum * 0.35;
    let ramSum = videoCardsSum * 0.1;
    let finalSum = videoCardsSum + (processorsSum * processors) + (ramSum * ram);
    if(videoCards > processors)
    {
        finalSum = finalSum * 0.85;
    }

    if(budget >= finalSum)
    {
        console.log(`You have ${(budget - finalSum).toFixed(2)} leva left!`);
    }
    else{
        console.log(`Not enough money! You need ${(finalSum - budget).toFixed(2)} leva more!`);
    }
}

calculate(['900', '2', '1', '3']);