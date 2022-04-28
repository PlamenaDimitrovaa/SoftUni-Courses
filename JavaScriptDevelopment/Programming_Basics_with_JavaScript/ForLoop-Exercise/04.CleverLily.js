function calculate(input){
    let age = Number(input[0]);
    let price = Number(input[1]);
    let pricePerToy = Number(input[2]);
    let sum = 0;
    let countOfToys = 0;

    for(let i = 1; i <= age; i++){
        if(i % 2 === 0){
            sum += 10 * (i / 2) - 1;
        }
        else{
            countOfToys++;
        }
    }

    sum += (countOfToys * pricePerToy);

    if(sum >= price){
        console.log(`Yes! ${(sum - price).toFixed(2)}`);
    }
    else{
        console.log(`No! ${(price - sum).toFixed(2)}`);
    }
}

calculate(['10', '170', '6']);