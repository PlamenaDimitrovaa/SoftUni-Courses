function solve(number){
    let sum = 0;
    let asString = number.toString();
    for(let i = 0; i < asString.length; i++){
        sum += Number(asString[i]);
    }
    console.log(sum);
}

solve(543);