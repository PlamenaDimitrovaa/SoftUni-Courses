function solve(input){
    let result = [];
    for(let i = 0; i < input.length; i++){
        let tokens = input[i].split(' / ');
        let [name, level, items] = tokens;
        level = Number(level);
        items = items ? items.split(', ') : [];
        result.push({name, level, items});
    }

    let json = JSON.stringify(result);

    console.log(json);
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);