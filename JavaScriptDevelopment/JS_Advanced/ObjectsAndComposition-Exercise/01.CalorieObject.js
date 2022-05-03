function solve(input){
    let object = {};

    for(let i = 0; i < input.length; i+=2){
        let productName = input[i];
        let calories = Number(input[i + 1]);
        object[productName] = calories;
    }

    console.log(object);
}