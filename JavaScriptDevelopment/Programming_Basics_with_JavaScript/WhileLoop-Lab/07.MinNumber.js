function maxNum(input){
    let index = 0;
    let minNumber = Number.POSITIVE_INFINITY;
    while(true){
        if(input[index] === 'Stop'){
            break;
        }  
        let currentNumber = Number(input[index]);
        if(currentNumber < minNumber){
            minNumber = currentNumber;
        }

        index++;
    }

    console.log(minNumber);
}
