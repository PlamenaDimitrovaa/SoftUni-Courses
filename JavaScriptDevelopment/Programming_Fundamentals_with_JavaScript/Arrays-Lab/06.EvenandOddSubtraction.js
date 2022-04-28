function solve(input){
    for(let i = 0; i <= input.length - 1; i++){
        input[i] = Number(input[i]);
    }

    let evenSum = 0;
    let oddSum = 0;

    for(let num of input){
        if(num % 2 === 0){
            evenSum += num;
        }
        else if(num % 2 !== 0){
            oddSum += num;
        }
    }

    console.log(Math.abs(evenSum - oddSum));
}