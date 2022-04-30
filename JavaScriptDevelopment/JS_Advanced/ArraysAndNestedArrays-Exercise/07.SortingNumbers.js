function solve(array){
    array = array.sort((a, b) => a - b);
    let result = [];

    while (array.length) {
        result.push(array.shift());
        if(array.length === 0){
            continue;
        }
        result.push(array.pop());
    }

    return result;
}
