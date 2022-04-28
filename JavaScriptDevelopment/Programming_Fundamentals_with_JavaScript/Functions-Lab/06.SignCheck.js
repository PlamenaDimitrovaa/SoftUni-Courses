function solve(num1, num2, num3){
    num1 = Number(num1);
    num2 = Number(num2);
    num3 = Number(num3);
    let count = 0;
    if(num1 <= 0){
        count++;
    }
    if(num2 <= 0){
        count++;
    }
    if(num3 <= 0){
        count++;
    }

    if(count % 2 === 0){
        console.log('Positive');
    }
    else{
        console.log('Negative');
    }
}