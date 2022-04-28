function calculate(input)
{
    let budget = Number(input[0]);
    let season = input[1];
    let count = Number(input[2]);
    let shipPrice = 0;

    if(season === 'Spring')
    {
        shipPrice = 3000;
    }
    else if(season === 'Summer')
    {
        shipPrice = 4200;
    }
    else if(season === 'Autumn')
    {
        shipPrice = 4200;
    }
    else if(season === 'Winter')
    {
        shipPrice = 2600;
    }

    if(count <= 6)
    {
        shipPrice = shipPrice * 0.90;
    }
    else if(count >= 7 && count <= 11)
    {
        shipPrice = shipPrice * 0.85;
    }
    else if(count >= 12)
    {
        shipPrice = shipPrice * 0.75;
    }

    if(count % 2 === 0 && season !== 'Autumn')
    {
        shipPrice = shipPrice * 0.95;
    }

    if(budget >= shipPrice)
    {
        console.log(`Yes! You have ${(budget - shipPrice).toFixed(2)} leva left.`);
    }
    else
    {
        console.log(`Not enough money! You need ${(shipPrice - budget).toFixed(2)} leva.`);
    }
}