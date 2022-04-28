function sum(input){
    let number = Number(input[0]);

    let index = 1;
    let currentNumber = Number(input[index]);
    let sum = currentNumber;
    while(sum < number){
        index++;
        currentNumber = Number(input[index]);
        sum += currentNumber;
    }

    console.log(sum);
}