function solve(input){
    let firstNum = Number(input[0]);
    let secondNum = Number(input[1]);
    let magicNum = Number(input[2]);
    let count = 0;
    let sum = 0;
    for(let i = firstNum; i <= secondNum; i++){
        for(let j = firstNum; j <= secondNum; j++){
            sum = i +j;
            count++;
            if(sum == magicNum){
                console.log(`Combination N:${count} (${i} + ${j} = ${magicNum})`);
                return;
            }
        }
    }

    console.log(`${count} combinations - neither equals ${magicNum}`);   
}

solve(['1', '10', '5']);