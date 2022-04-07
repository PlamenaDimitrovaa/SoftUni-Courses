function calculate(input)
{
    let month = input[0];
    let days = Number(input[1]);
    let priceStudio = 0;
    let priceApart = 0;

    if(month === 'May' || month === 'October')
    {
        priceStudio = (days * 50);
        priceApart = (days * 65);
    }
    else if(month === 'June' || month === 'September')
    {
        priceStudio = (days * 75.20);
        priceApart = (days * 68.70);
    }
    else if(month === 'July' || month === 'August')
    {
        priceStudio = (days * 76);
        priceApart = (days * 77);
    }


    if(days > 14 && (month === 'May' || month === 'October'))
    {
        priceStudio = (priceStudio * 0.70);
    }
    else if(days > 7 && (month === 'May' || month === 'October'))
    {
        priceStudio = (priceStudio * 0.95);
    }
    else if(days > 14 && (month === 'June' || month === 'September'))
    {
        priceStudio = (priceStudio * 0.80);
    }

    if(days > 14)
    {
        priceApart = (priceApart * 0.90);
    }

    console.log(`Apartment: ${priceApart.toFixed(2)} lv.`);
    console.log(`Studio: ${priceStudio.toFixed(2)} lv.`);
}