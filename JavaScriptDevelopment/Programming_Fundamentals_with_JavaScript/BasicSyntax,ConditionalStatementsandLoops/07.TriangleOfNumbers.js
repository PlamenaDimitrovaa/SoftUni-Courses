function solve(number){
    for (let row = 1; row <= number; row++) {
        let output = "";
        for (let col = 1; col <= row; col++) {
            output += row + " ";
        }

        console.log(output);
    }
}

solve(5);