function solve(numOne, numTwo, operator){
    numOne = Number(numOne);
    numTwo = Number(numTwo);
    if(operator === 'multiply'){
       console.log(multiply(numOne, numTwo));
    }
    else if(operator === 'divide'){
        console.log(divide(numOne, numTwo));
    }
    else if(operator === 'add'){
        console.log(add(numOne, numTwo));
    }
    else if(operator === 'subtract'){
        console.log(subtract(numOne, numTwo));
    }


    function multiply(numOne, numTwo){
        return numOne * numTwo;
    }
    function divide(numOne, numTwo){
        return numOne / numTwo;
    }
    function add(numOne, numTwo){
        return numOne + numTwo;
    }
    function subtract(numOne, numTwo){
        return numOne - numTwo;
    }
}

solve('5', '5', 'multiply');