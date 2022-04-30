function solve(array, flavor1, flavor2){
    let first = array.indexOf(flavor1);
    let second = array.indexOf(flavor2);
    let result = array.slice(first, second + 1);
    return result;
}
