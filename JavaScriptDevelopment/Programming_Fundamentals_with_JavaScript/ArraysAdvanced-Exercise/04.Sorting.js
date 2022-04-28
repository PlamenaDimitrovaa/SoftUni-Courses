function solve(array){
    let result = [];
    array = array.sort((a, b) => a - b);

    while(array.length !== 0){
        result.push(array.pop());
        result.push(array.shift());
    }

    console.log(result.join(' '));
}

solve([1, 21, 3, 52, 69, 63, 31, 2, 18, 94]);