function calculate(input)
{
    let budget = Number(input[0]);
    let statists = Number(input[1]);
    let pricePerOneStatist = Number(input[2]);
    let decor = (budget * 0.1);
    let statistsPrice = statists * pricePerOneStatist;
    if(statists > 150)
    {
        statistsPrice = statistsPrice * 0.9;
    }

    let totalSum = decor + statistsPrice;
    if(totalSum > budget)
    {
        console.log("Not enough money!");
        console.log(`Wingard needs ${(totalSum - budget).toFixed(2)} leva more.`);
    }
    else
    {
        console.log("Action!");
        console.log(`Wingard starts filming with ${(budget - totalSum).toFixed(2)} leva left.`);
    }
}