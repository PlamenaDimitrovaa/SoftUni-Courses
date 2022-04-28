function solve(input){
    let object = {};
    for (const element of input) {
        let tokens = element.split(':');
        let name = tokens[0];
        let address = tokens[1];
        object[name] = address;
    }

    sorted = Object.keys(object)
    .sort()
    .reduce(function (acc, key) { 
        acc[key] = object[key];
        return acc;
    }, {});

    for (const el in sorted) {
        console.log(`${el} -> ${object[el]}`);
    }
}

solve(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']);