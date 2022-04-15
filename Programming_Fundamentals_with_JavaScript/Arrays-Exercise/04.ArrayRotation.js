function solve(array, number){
    for (let i = 0; i < number; i++) {
        array.push(array[0]);
        array.shift();
    }

    console.log(array.join(" "));
}