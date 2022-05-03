function solve(input){
    let result = [];

    input.shift();
    
    for (let el of input) {
        let split = el.split('|');
        let currentTown = split[1].trim();
        let currentLatitude = Number(split[2].trim()).toFixed(2);
        let currentLongitude = Number(split[3].trim()).toFixed(2); 
        let object = {};

        object.Town = currentTown;
        object.Latitude = Number(currentLatitude);
        object.Longitude = Number(currentLongitude);  

        result.push(object);
    }

    let json = JSON.stringify(result);

    console.log(json);
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
);