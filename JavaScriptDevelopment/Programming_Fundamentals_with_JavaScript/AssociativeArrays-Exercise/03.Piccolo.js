function solve(input){
    let parking = new Set();
    for (const line of input) {
        let [command, number] = line.split(', ');
        if(command === 'IN'){
            parking.add(number);
        }else{
            parking.delete(number);
        }
    }

    let result = Array.from(parking);
    result.sort();

    if(parking.size === 0){
        console.log("Parking Lot is empty");
    }else{
        for (const car of result) {
            console.log(car);
        }
    }
}

solve(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']);