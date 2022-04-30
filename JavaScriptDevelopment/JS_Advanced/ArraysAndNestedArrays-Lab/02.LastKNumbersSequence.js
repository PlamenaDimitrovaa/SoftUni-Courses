function solve(n, k){
    let result = [];
    result.push(1);
    for(let i = 0; i < n - 1; i++){
        let lastK = result.slice(-k);
        let sum = 0;
        for(let element of lastK){
            sum += element;
        }

        result.push(sum);
    }
    
    return result;
}

solve(6, 3);
solve(8, 2);