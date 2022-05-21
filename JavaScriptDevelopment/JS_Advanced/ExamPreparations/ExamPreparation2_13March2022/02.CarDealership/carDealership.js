class CarDealership {
    constructor(name){
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage){
        if(!model || horsepower < 0 || price < 0 || mileage < 0){
            throw new Error('Invalid input!');
        }

        let currCar = {
            model, 
            horsepower,
            price,
            mileage,
        }

        this.availableCars.push(currCar);
        return `New car added: ${currCar.model} - ${currCar.horsepower} HP - ${(currCar.mileage).toFixed(2)} km - ${(currCar.price).toFixed(2)}$`;
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

        let soldCar = {
            model: car.model,
            horsepower: car.horsepower,
            soldPrice: soldPrice,
        }
        
        this.soldCars.push(soldCar);
        this.totalIncome += soldPrice;
        return `${car.model} was sold for ${(soldPrice).toFixed(2)}$`;
    }

    currentCar(){
        let result = [];
        result.push(`-Available cars:`);
        this.availableCars.forEach(x => {result.push(`---${x.model} - ${x.horsepower} HP - ${(x.mileage).toFixed(2)} km - ${(x.price).toFixed(2)}$`)});
        if(this.availableCars.length > 0){
            return result.join('\n');
        } else{
            return `There are no available cars`;
        }
    }

    salesReport(criteria){
        if(criteria == 'horsepower'){
            this.soldCars = this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
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
