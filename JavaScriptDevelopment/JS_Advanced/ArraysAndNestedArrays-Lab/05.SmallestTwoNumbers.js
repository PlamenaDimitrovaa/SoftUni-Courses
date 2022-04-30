function solve(input){
    input.sort((a,b) => a - b);
    let arr = [];
    for(let i = 0; i < 2; i++){
        arr.push(input[i]);
    }

    console.log(arr.join(' '));
}