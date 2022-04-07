function calculate(input)
{
    let type = input[0];
    let numFlowers = Number(input[1]);
    let budget = Number(input[2]);
    let price = 0;

    if(type === "Roses")
    {
        price = numFlowers * 5;
    }
    else if(type === "Dahlias")
    {
        price = numFlowers * 3.80;
    }
    else if(type === "Tulips")
    {
        price = numFlowers * 2.80;
    }
    else if(type === "Narcissus")
    {
        price = numFlowers * 3;
    }
    else if(type === "Gladiolus")
    {
        price = numFlowers * 2.50;
    }

    if(type === "Roses" && numFlowers > 80)
    {
        price -= price * 0.1;
    }
    else if(type === "Dahlias" && numFlowers > 90)
    {
        price -= price * 0.15;
    } 
    else if(type === "Tulips" && numFlowers > 80)
    {
        price -= price * 0.15;
    } 
    else if(type === "Narcissus" && numFlowers < 120)
    {
        price += price * 0.15;
    } 
    else if(type == "Gladiolus" && numFlowers < 80)
    {
        price += price * 0.2;
    }

    if(budget >= price)
    {
        console.log(`Hey, you have a great garden with ${numFlowers} ${type} and ${(budget - price).toFixed(2)} leva left.`);
    }
    else
    {
        console.log(`Not enough money, you need ${(price - budget).toFixed(2)} leva more.`);
    }
}
calculate(["Roses", "55", "250"]);
calculate(["Tulips", "88", "260"]);