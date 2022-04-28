function solve(array){
    numArray = array.map(Number);
    let sum = numArray.reduce((a, b) => a + b);
    console.log(sum);
    let inverseSum = 0;
    for(let i = 0; i < numArray.length; i++){
        inverseSum += 1 / numArray[i];
    }

    console.log(inverseSum);
    let stringConcat = numArray.join('');
    console.log(stringConcat);
}