function solve(input){
    let juices = {};
    let bottles = {};

    for (let line of input) {
        let [juiceName, juiceQty] = line.split(' => ');
        juiceQty = Number(juiceQty);
        if(!juices[juiceName]){
            juices[juiceName] = 0;
        }
        
        juices[juiceName] += juiceQty;

        while(juices[juiceName] >= 1000){
            juices[juiceName] -= 1000;
            if(!bottles[juiceName]){
                bottles[juiceName] = 0;
            }

            bottles[juiceName] += 1;
        }
    }

    for (let obj of Object.keys(bottles)) {
        console.log(`${obj} => ${bottles[obj]}`)
    }
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);