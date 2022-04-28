function solve(input){
    input = input.map(Number);
    input = input.filter((item, pos, a) => a.indexOf(item) == pos);

    console.log(input.join(' '));
}

solve([7, 8, 9, 7, 2, 3, 4, 1, 2]);