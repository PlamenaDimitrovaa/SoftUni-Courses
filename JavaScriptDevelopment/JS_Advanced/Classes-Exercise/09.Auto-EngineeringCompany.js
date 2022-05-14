function solve(input) {
    let brands = {};

    for (const line of input) {
        let [brand, model, producedCars] = line.split(' | ');    
        producedCars = Number(producedCars);

        if (!brands[brand]) {
            brands[brand] = {};
        }

        if (!brands[brand][model]) {
            brands[brand][model] = 0;
        }

        brands[brand][model] += producedCars;
    }

    let brandsKeys = Object.keys(brands);

    for (const brand of brandsKeys) {
        let models = Object.keys(brands[brand]);

        console.log(brand);
        for (const model of models) {
            console.log(`###${model} -> ${brands[brand][model]}`);
        }
    }
}