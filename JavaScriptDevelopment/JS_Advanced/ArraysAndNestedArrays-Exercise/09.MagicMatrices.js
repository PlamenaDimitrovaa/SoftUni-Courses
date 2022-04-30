function solve(matrix){
    let rowSums = [];
    let colSums = [];
    
    for (let i = 0; i < matrix.length; i++) {
        let row = matrix[i];
        let sum = row.reduce((a, b) => (a + b), 0);
        rowSums.push(sum);
    }

    for (let i = 0; i < matrix.length; i++) {
        let newRow = [];
        for (let j = 0; j < matrix.length; j++) {
            let index = matrix.length - 1 - j;
            newRow.push(matrix[index][i]);
        }

        let sum = newRow.reduce((a, b) => (a + b), 0);
        colSums.push(sum);
    }

    return rowSums.concat(colSums).every((el, i, arr) => el === arr[0]);
}


solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );