function solve(input){

    let products = [];

    while(input.length > 0){
        let [town, product, price] = input.shift().split(' | ');
        
        price = Number(price);

        if(products.filter(x => x.product === product).length > 0){

            let object = products.find(x => x.product === product);

            if(object.price > price){
                object.price = price;
                object.town = town;
            }
        } else{
            let object = {product, town, price};
            products.push(object);
        }
    }
    for (let product of products) {
        console.log(`${product.product} -> ${product.price} (${product.town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);