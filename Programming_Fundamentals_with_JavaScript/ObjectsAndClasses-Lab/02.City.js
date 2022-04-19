function solve(input){
    for(let key of Object.keys(input)){
        console.log(`${key} -> ${input[key]}`);
    }
}

solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});