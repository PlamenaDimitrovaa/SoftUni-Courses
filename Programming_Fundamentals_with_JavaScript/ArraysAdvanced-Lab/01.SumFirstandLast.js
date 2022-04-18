function solve(input){
    let first = input.shift();
    let last = input.pop();
    let result = Number(first) + Number(last);
    console.log(result);
}

solve(['20', '60', '40']);