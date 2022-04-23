function solve(input){
    let object = {};
    for (const element of input) {
        let tokens = element.split(' ');
        let name = tokens[0];
        let phone = tokens[1];
        object[name] = phone;
    }

    for(let name in object){
        console.log(`${name} -> ${object[name]}`);
    }
}