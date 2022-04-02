function delivery(input)
{
    let chickenMenu = Number(input[0]);
    let fishMenu = Number(input[1]);
    let vegetarianMenu = Number(input[2]);
    let sum = ((chickenMenu * 10.35) + (fishMenu * 12.40) + (vegetarianMenu * 8.15));
    let dessert = sum * 0.2;
    let totalSum = sum + dessert + 2.50;
    console.log(totalSum);
}

delivery(["2 ","4 ","3 "]);