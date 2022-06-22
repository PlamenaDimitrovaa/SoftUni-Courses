 class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {
        let uniqueProducts = new Set();

        for (const vegetable of vegetables) {
            let [type, quantity, price] = vegetable.split(' ');
            quantity = Number(quantity);
            price = Number(price);

            if (!this.availableProducts.find(p => p.type === type)) {
                let newProduct = {
                    type: type,
                    quantity: 0,
                    price: 0
                };

                this.availableProducts.push(newProduct);
            }

            let currProduct = this.availableProducts.find(p => p.type === type);
            currProduct.quantity += quantity;
            currProduct.price = price > currProduct.price ? price : currProduct.price;

            uniqueProducts.add(type);
        }

        return `Successfully added ${Array.from(uniqueProducts).join(', ')}`;
    }

    buyingVegetables(selectedProducts) {
        let totalPrice = 0;

        for (const product of selectedProducts) {
            let [type, quantity] = product.split(' ');
            quantity = Number(quantity);

            if (!this.availableProducts.find(p => p.type === type)) {
                throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            let currProduct = this.availableProducts.find(p => p.type === type);

            if (currProduct.quantity < quantity) {
                throw new Error(`The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            totalPrice += quantity * currProduct.price;
            currProduct.quantity -= quantity;
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {
        if (!this.availableProducts.find(p => p.type === type)) {
            throw new Error(`${type} is not available in the store.`);
        }

        let currProduct = this.availableProducts.find(p => p.type === type);

        if (quantity > currProduct.quantity) {
            currProduct.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`;
        }

        currProduct.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`;
    }

    revision() {
        let result = [];
        result.push('Available vegetables:');
        
        this.availableProducts
            .sort((a, b) => a.price - b.price)
            .forEach(p => result.push(`${p.type}-${p.quantity}-$${p.price}`));

        result.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`);

        return result.join('\n');
    }
}