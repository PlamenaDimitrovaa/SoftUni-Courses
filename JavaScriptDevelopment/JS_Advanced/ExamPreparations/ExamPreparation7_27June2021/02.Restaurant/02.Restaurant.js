class Restaurant {
    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const product of products) {
            let [name, quantity, price] = product.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            if (this.budgetMoney >= price) {
                if (!this.stockProducts.hasOwnProperty(name)) {
                    this.stockProducts[name] = 0;
                }

                this.stockProducts[name] += quantity;
                this.budgetMoney -= price;

                this.history.push(`Successfully loaded ${quantity} ${name}`);
            } else {
                this.history.push(`There was not enough money to load ${quantity} ${name}`);
            }
        }

        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {
                products: neededProducts,
                price: price
            }
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let countOfMeals = Object.keys(this.menu).length;

        if (countOfMeals === 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else if (countOfMeals === 0 || countOfMeals >= 2) {
            return `Great idea! Now with the ${meal} we have ${countOfMeals} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        let meals = Object.keys(this.menu);
        let result = [];

        for (const meal of meals) {
            result.push(`${meal} - $ ${this.menu[meal].price}`);
        }

        if (meals.length === 0) {
            return 'Our menu is not ready yet, please come later...';
        }

        return result.join('\n').trim();
    }

    makeTheOrder(meal) {
        if (!this.menu.hasOwnProperty(meal)) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const product of neededProducts) {
            let [name, quantity] = product.split(' ');
            quantity = Number(quantity);
            
            if (!this.stockProducts[name] || this.stockProducts[name] === 0 || this.stockProducts[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        for (const product of neededProducts) {
            let [name, quantity] = product.split(' ');
            quantity = Number(quantity);

            this.stockProducts[name] -= quantity;
        }

        this.budgetMoney += this.menu[meal].price;

        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}
