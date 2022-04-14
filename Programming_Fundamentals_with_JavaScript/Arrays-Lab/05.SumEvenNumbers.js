function solve(input){
    for(let i = 0; i <= input.length - 1; i++){
        input[i] = Number(input[i]);
    }

    let sum = 0;
    for(let num of input){
        if(num % 2 === 0){
            sum += num;
        }
    }

    console.log(sum);
}

solve(['1','2','3','4','5','6']);