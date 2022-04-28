function solve(input){
    let firstPart = input.substring(0, input.length / 2);
    let secondPart = input.substring(input.length / 2);

    let first = '';
    for(let i = firstPart.length - 1; i >= 0; i--){
        first += firstPart[i];
    }

    let second = '';
    for(let i = secondPart.length - 1; i >= 0; i--){
        second += secondPart[i];
    }

    console.log(`${first}`);
    console.log(second);
}

solve('tluciffiDsIsihTgnizamAoSsIsihT');