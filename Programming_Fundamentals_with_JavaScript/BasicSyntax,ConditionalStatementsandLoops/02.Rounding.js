function solve(number, rounder){
    if(rounder > 15){
        rounder = 15;
    }

    number = number.toFixed(rounder);

    console.log(parseFloat(number));
}