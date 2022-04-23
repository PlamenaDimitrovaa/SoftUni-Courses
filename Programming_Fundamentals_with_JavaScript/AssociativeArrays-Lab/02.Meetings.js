function solve(input){
    let object = {};
    let array = [];
    for (const day of input) {
        let tokens = day.split(' ');
        let currentDay = tokens[0];
        let name = tokens[1];
        if(array.includes(currentDay)){
            console.log(`Conflict on ${currentDay}!`);
            continue;
        }
        else{
            array.push(currentDay);
            object[currentDay] = name;
            console.log(`Scheduled for ${currentDay}`);
        }
    }

    for (const day in object) {
       console.log(`${day} -> ${object[day]}`);
    }
}

solve(['Monday Peter',
'Wednesday Bill',
'Monday Tim',
'Friday Tim']);