function solve(number){
    let oddSum = 0;
    let evenSum = 0;

    number = Number(number);
    while(number > 0){
        let currentDigit = number % 10;
        if(currentDigit % 2 === 0){
            evenSum += currentDigit;
        }
        else
        {
            oddSum += currentDigit;
        }
        number = Math.floor(number / 10);
    }

    return `Odd sum = ${oddSum}, Even sum = ${evenSum}`;
}

solve([1000435]);