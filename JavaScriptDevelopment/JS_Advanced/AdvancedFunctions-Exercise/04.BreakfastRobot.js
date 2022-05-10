function solution() {
    let ingredients = {
        'protein': 0,
        'carbohydrate': 0,
        'fat': 0,
        'flavour': 0
    }

    let recipes = {
        'apple': new Map(),
        'lemonade': new Map(),
        'burger': new Map(),
        'eggs': new Map(),
        'turkey': new Map()
    }

    recipes.apple.set('carbohydrate', 1);
    recipes.apple.set('flavour', 2);
    recipes.lemonade.set('carbohydrate', 10);
    recipes.lemonade.set('flavour', 20);
    recipes.burger.set('carbohydrate', 5);
    recipes.burger.set('fat', 7);
    recipes.burger.set('flavour', 3);
    recipes.eggs.set('protein', 5);
    recipes.eggs.set('fat', 1);
    recipes.eggs.set('flavour', 1);
    recipes.turkey.set('protein', 10);
    recipes.turkey.set('carbohydrate', 10);
    recipes.turkey.set('fat', 10);
    recipes.turkey.set('flavour', 10);

    function restock(microelement, quantity) {
        ingredients[microelement] += quantity;
        
        return 'Success';
    }

    function prepare(recipe, quantity) {
        for (const [key, value] of recipes[recipe]) {
            if (ingredients[key] - value * quantity < 0) {
                return `Error: not enough ${key} in stock`;
            }
        }

        for (const [key, value] of recipes[recipe]) {
            ingredients[key] -= quantity * value; 
        }

        return 'Success';
    }

    function report() {
        return `protein=${ingredients.protein} carbohydrate=${ingredients.carbohydrate} fat=${ingredients.fat} flavour=${ingredients.flavour}`;
    }

    return function commands(line) {
        let splittedLine = line.split(' ');
        let command = splittedLine[0];

        if (command === 'restock') {
            let ingredient = splittedLine[1];
            let quantity = Number(splittedLine[2]);

            return restock(ingredient, quantity);
        } else if (command === 'prepare') {
            let recipe = splittedLine[1];
            let quantity = Number(splittedLine[2]);

            return prepare(recipe, quantity);
        } else if(command === 'report') {
            return report();
        }
    }
}
