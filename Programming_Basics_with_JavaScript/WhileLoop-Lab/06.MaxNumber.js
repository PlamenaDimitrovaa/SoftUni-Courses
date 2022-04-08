function maxNum(input){
    let index = 0;
    let maxNumber = Number.NEGATIVE_INFINITY;
    while(true){
        if(input[index] === 'Stop'){
            break;
        }  
        let currentNumber = Number(input[index]);
        if(currentNumber > maxNumber){
            maxNumber = currentNumber;
        }

        index++;
    }

    console.log(maxNumber);
}

maxNum(["100",
"99",
"80",
"70",
"Stop"]);
