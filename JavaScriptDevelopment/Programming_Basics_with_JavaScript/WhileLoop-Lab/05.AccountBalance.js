function solve(input){
    let index = 0;
    let sum = 0;
    while(true){
        if(input[index] === 'NoMoreMoney'){
            break;
        }
        else if(input[index] < 0){
            console.log("Invalid operation!");
            break;
        }

        let currentAmount = Number(input[index]);
        sum += currentAmount;
        console.log(`Increase: ${currentAmount.toFixed(2)}`);
        index++;
    }

    console.log(`Total: ${sum.toFixed(2)}`);
}

solve(["5.51", 
"69.42",
"100",
"NoMoreMoney"]);