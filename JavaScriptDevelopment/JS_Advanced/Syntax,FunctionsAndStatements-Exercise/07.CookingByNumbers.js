function solve(number, op1, op2, op3, op4, op5){
    let inputAsNumber = Number(number);
    let arrOfCommands = [op1, op2, op3, op4, op5];

    let chop = function() {
        return inputAsNumber / 2;
    };

    let dice = function(){
        return Math.sqrt(inputAsNumber);
    };

    let spice = function(){
        return inputAsNumber+=1;
    };

    let bake = function(){
        return inputAsNumber * 3;
    };

    let fillet = function(){
        return inputAsNumber * 0.80;
    };

    for(let i = 0; i < arrOfCommands.length; i++){
        let currentCommand = arrOfCommands[i];
        switch(currentCommand){
            case 'chop': inputAsNumber = chop(inputAsNumber); console.log(inputAsNumber); break;
            case 'dice': inputAsNumber = dice(inputAsNumber); console.log(inputAsNumber); break;
            case 'spice': inputAsNumber = spice(inputAsNumber); console.log(inputAsNumber); break;
            case 'bake': inputAsNumber = bake(inputAsNumber); console.log(inputAsNumber); break;
            case 'fillet': inputAsNumber = fillet(inputAsNumber); console.log(inputAsNumber); break;
        }
    }
}