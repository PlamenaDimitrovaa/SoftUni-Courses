function solve(matrix){
    let max = Number.MIN_SAFE_INTEGER;
    for (let row = 0; row < matrix.length; row++) {
        let currRow = matrix[row];
        for (let col = 0; col < currRow.length; col++) {
            if(max < matrix[row][col]){
                max = matrix[row][col];
            }
        }
    }

    return max;
}

solve([[20, 50, 10],
    [8, 33, 145]]
   );