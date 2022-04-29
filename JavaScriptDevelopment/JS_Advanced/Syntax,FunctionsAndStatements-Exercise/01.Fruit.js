function solve(fruit, grams, pricePerKg){
    grams = Number(grams);
    pricePerKg = Number(pricePerKg);
    let kg = grams / 1000;
    let result = kg * pricePerKg;
    console.log(`I need $${result.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${fruit}.`);
}