function solve(num, inputArr){
    let arr = [];
    for(let i = 0; i < num; i++){
        arr.push(inputArr[i]);
    }

    arr.reverse();
    let output = ""
    for(let i = 0; i <= arr.length - 1; i++){
        output += `${arr[i]} `;
    }

    console.log(output);
}