function solve(input) {
    let carsObj = {};
    let utilityObj = {
        create,
        createAndInherit,
        set,
        print
    };

    input.forEach(i => {
        const args = i.split(' ');
        let command = args[0];
        let name = args[1];
        
        if (command === 'create') {
            if (args[2]) {
                let parentName = args[3];

                utilityObj.createAndInherit(name, parentName);
            } else {
                utilityObj.create(name);                    
            }
        } else if (command === 'set') {
            const key = args[2];
            const value = args[3];
            utilityObj.set(name, key, value);
        } else if (command === 'print') {
            utilityObj.print(name);
        }
    });

    function create(name) {
        carsObj[name] = {};
    }

    function createAndInherit(name, parentName) {
        create(name);
        let currObj = carsObj[name];   
        currObj = Object.setPrototypeOf(currObj, carsObj[parentName]);
    }

    function set(name, key, value) {
        carsObj[name][key] = value;
    }

    function print(name) {
        let print = '';
        const carToPrint = carsObj[name];
        for (const car in carToPrint) { 
            print += `${car}:${carToPrint[car]},`;
        }

        console.log(print.slice(0, -1));
    }
}
