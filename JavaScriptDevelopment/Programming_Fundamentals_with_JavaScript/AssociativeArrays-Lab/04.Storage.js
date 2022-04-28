function solve(input){
    let object = {};
    let array = [];

    for (const element of input) {
        let tokens = element.split(' ');
        let item = tokens[0];
        let quantity = Number(tokens[1]);
        if(array.includes(item)){
            object[item] += quantity;
        }
        else{
            object[item] = quantity;
            array.push(item);
        }
    }

    for (const element in object) {
        console.log(`${element} -> ${object[element]}`);
    }
}