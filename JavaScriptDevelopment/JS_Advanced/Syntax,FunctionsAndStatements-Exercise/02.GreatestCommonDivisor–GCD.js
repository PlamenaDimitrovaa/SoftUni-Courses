function solve(num1, num2){
    num1 = Number(num1);
    num2 = Number(num2);
    let end = Math.max(num1, num2);

    let greatestNum;
    for(let i = 0; i < end; i++ ){
        if(num1 % i === 0 && num2 % i === 0){
            greatestNum = i;
        }
    }
    
    console.log(greatestNum);
}

solve(15,5);
solve(2154, 458);