function calculate(input)
{
    let budget = Number(input[0]);
    let season = input[1];
    let finalPrice = 0;
    let destination = "";
    let type = "";

    if(budget <= 100)
    {
        destination = "Bulgaria";
        if(season === 'summer')
        {
            type = "Camp";
            finalPrice = budget * 0.30;
        }
        else if(season === 'winter')
        {
            type = "Hotel";
            finalPrice = budget * 0.70;
        }
    }
    else if(budget > 100 && budget <= 1000)
    {
        destination = "Balkans";
        if(season === 'summer')
        {
            type = "Camp";
            finalPrice = budget * 0.40;
        }
        else if(season === 'winter')
        {
            type = "Hotel";
            finalPrice = budget * 0.80;
        }
    }
    else if(budget > 1000)
    {
        type = "Hotel";
        destination = "Europe";
        finalPrice = budget * 0.90;
    }

    console.log(`Somewhere in ${destination}`);
    console.log(`${type} - ${finalPrice.toFixed(2)}`);
}    