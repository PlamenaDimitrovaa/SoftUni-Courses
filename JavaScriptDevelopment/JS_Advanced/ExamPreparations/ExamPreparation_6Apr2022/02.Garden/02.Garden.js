class Garden{
    constructor(spaceAvailable){
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired){
        spaceRequired = Number(spaceRequired);
        if(this.spaceAvailable < spaceRequired){
            throw new Error("Not enough space in the garden.");
        }

        let currentPlant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0,
        }

        this.plants.push(currentPlant);
        this.spaceAvailable -= spaceRequired;

        return `The ${plantName} has been successfully planted in the garden.`
    }

    ripenPlant(plantName, quantity){
        quantity = Number(quantity);
        if(!this.plants.some(x => x.plantName == plantName)){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        let currentPlant = this.plants.find(x => x.plantName == plantName);
        if(currentPlant.ripe == true){
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if(quantity <= 0){
            throw new Error("The quantity cannot be zero or negative.");
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        if(quantity == 1){
            return `${quantity} ${plantName} has successfully ripened.`;
        } else if(quantity > 1){
            return `${quantity} ${plantName}s have successfully ripened.`;
        }
    }

    harvestPlant(plantName){
        if(!this.plants.some(x => x.plantName == plantName)){
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        let currentPlant = this.plants.find(x => x.plantName == plantName);
        if(currentPlant.ripe == false){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        this.plants = this.plants.filter(x => x.plantName !== plantName);
        this.spaceAvailable += currentPlant.spaceRequired;

        let plantToAdd = {
            plantName,
            quantity: currentPlant.quantity,
        }

        this.storage.push(plantToAdd);

        return `The ${plantName} has been successfully harvested.`
    }

    generateReport(){
        let result = [];

        result.push(`The garden has ${ this.spaceAvailable } free space left.`);
        let sortedPlants = this.plants.sort((a, b) => a.plantName.localeCompare(b.plantName));
        let pplants = [];

        for (const plant of sortedPlants) {
            pplants.push(plant.plantName);
        }

        result.push(`Plants in the garden: ${pplants.join(', ')}`);
        let sstorage = [];
        if(this.storage.length <= 0){
            result.push("Plants in storage: The storage is empty.");
        } else{
            for (const plant of this.storage) {
                sstorage.push(`${plant.plantName} (${plant.quantity})`);
            }
            result.push(`Plants in storage: ${sstorage.join(', ')}`);
        }

        return result.join('\n');
    }
}



