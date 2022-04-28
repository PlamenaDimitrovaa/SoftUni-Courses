function solve(array){
    array.reverse();
    let output = "";
    for(let i = 0; i <= array.length - 1; i++){
        output += `${array[i]} `;
    }

    console.log(output);
}