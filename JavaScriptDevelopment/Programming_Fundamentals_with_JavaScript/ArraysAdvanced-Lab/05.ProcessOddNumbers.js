function solve(arr){
    let filtered = arr.filter((x, i) => i % 2 !== 0);
    let doubled = filtered.map(x => x * 2);
    let result = doubled.reverse();
    console.log(result.join(' '));
}