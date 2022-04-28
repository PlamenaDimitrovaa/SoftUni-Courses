function solve(array){
    let sum1 = 0;
    for(let i = 0; i < array.length; i++){
        array[i] = Number(array[i]);
        sum1 += array[i];
    }

    let sum2 = 0;
    for(let i = 0; i < array.length; i++){
        array[i] = Number(array[i]);
        if(array[i] % 2 === 0){
            array[i] = array[i] + i;
        }
        else{
            array[i] = array[i] - i;
        }

        sum2 += array[i];
    }
    console.log(array);
    console.log(sum1);
    console.log(sum2);
}

solve([5, 15, 23, 56, 35]);

solve([-5, 11, 3, 0, 2]);