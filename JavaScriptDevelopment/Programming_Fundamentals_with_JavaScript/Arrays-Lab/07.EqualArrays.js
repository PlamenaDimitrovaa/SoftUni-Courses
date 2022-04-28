function solve(array1, array2){
    let sum = 0;
    let areEqual = true;
    for(let i = 0; i < array1.length; i++){
        array1[i] = Number(array1[i]);
        sum += array1[i];
    }

    for(let i = 0; i < array2.length; i++){
        array2[i] = Number(array2[i]);
    }

    for(let i = 0; i < array1.length; i++){
        if(array1[i] !== array2[i]){
            console.log(`Arrays are not identical. Found difference at ${i} index`);
            areEqual = false;
            break;
        }
    }

    if(areEqual){
        console.log(`Arrays are identical. Sum: ${sum}`);
    }
}