function solve(number){
    if(typeof number === "number"){
        console.log((Math.PI * (number ** 2)).toFixed(2));
        return;
    } else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(number)}.`);
    }
}
