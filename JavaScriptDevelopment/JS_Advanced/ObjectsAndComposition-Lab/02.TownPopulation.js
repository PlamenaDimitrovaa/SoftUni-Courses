function solve(arr){
    let result = {};

    for (let info of arr) {
        let infoArr = info.split(' <-> ');
        let name = infoArr[0];
        population = Number(infoArr[1]);
        if(!result[name]){
            result[name] = 0;
        }
        result[name] += population;
    }

    for (let key in result) {
        console.log(`${key} : ${result[key]}`);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']);