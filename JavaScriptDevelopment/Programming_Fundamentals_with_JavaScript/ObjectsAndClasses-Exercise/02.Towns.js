function solve(input){
    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(" | ");

        let[town, latitude, longitude] = tokens;
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        let object = {};
        object.town = town;
        object.latitude = latitude;
        object.longitude = longitude;

        console.log(object);
    }
}

solve(['Plovdiv | 136.45 | 812.575']);