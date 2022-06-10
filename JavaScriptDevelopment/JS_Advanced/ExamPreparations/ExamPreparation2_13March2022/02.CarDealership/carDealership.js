class CarDealership {
    constructor(name){
        this.name = name;
        this.availableCars= [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage){
        if(model == '' || horsepower < 0 || price < 0 || mileage < 0){
            throw new Error('Invalid input!');
        } else{
            let currentCar = {
                model,
                horsepower,
                price,
                mileage,
            }

            this.availableCars.push(currentCar);
            return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
        }
    }

    sellCar(model, desiredMileage){
        let car = this.availableCars.find(x => x.model == model);
        let index = this.availableCars.findIndex(x => x.model == model);

        if(car == undefined || index == -1){
            throw new Error(`${model} was not found!`);
        }

        let soldPrice = 0;
            let difference = Math.abs(desiredMileage - car.mileage);
            if(car.mileage <= desiredMileage){
                soldPrice = car.price;
            } else if(difference <= 40000){
                soldPrice = car.price * 0.95;
            } else if(difference > 40000){
                soldPrice = car.price * 0.90;
            }

            this.availableCars.splice(index, 1);

        let carToAdd = {
            model: car.model,
            horsepower: car.horsepower,
            soldPrice: soldPrice,
        }

        this.soldCars.push(carToAdd);
        this.totalIncome += soldPrice;
        return `${model} was sold for ${soldPrice.toFixed(2)}$`;
    }

    currentCar(){
        let result = [];
        result.push("-Available cars:");
        for (let car of this.availableCars) {
            result.push(`---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$`);
        }
        
        if(this.availableCars.length > 0){
            return result.join('\n');
        } else{
            throw new Error("There are no available cars"); 
        }
    }

    salesReport(criteria){
        if(criteria == 'horsepower'){
            this.soldCars = this.soldCars.sort((a,b) => b.horsepower - a.horsepower);
        } else if(criteria == 'model'){
            this.soldCars = this.soldCars.sort(a.model.localeCompare(b.model));
        } else{
            throw new Error('Invalid criteria!');
        }

        let result = [];
        result.push(`-${this.name} has a total income of ${(this.totalIncome).toFixed(2)}$`);
        result.push(`-${this.soldCars.length} cars sold:`);
        this.soldCars.forEach(x => {result.push(`---${x.model} - ${x.horsepower} HP - ${(x.soldPrice).toFixed(2)}$`)});
        return result.join('\n');
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));

