function result(input)
{
    let dogsPrice = Number(input[0]);
    let catsPrice = Number(input[1]);
    let totalPrice = (dogsPrice * 2.50) + (catsPrice * 4.00);
    console.log(`${totalPrice} lv.`);
}

result(['5', '4']);
result(['13', '9']);
