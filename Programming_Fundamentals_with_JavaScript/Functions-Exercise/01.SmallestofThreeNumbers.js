function solve(num1, num2, num3){
    let minNum = num1;
    if(minNum > num2){
        minNum = num2;
    }

    if(minNum > num3){
        minNum = num3;
    }

    return minNum;
}