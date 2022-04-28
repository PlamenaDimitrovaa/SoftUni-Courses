function solve(array){
    array.sort();
    let count = 1; 
    for(let element of array){
        console.log(`${count}.${element}`);
        count++;
    }
}