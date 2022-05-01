function solve(name, population, treasury){
    let result = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes: function(){
            this.treasury += population * this.taxRate;
        },

        applyGrowth: function(percentage){
             this.population += Math.floor(this.population * percentage / 100);
        },

        applyRecession(percentage) {
            this.treasury -= Math.floor(this.treasury * percentage / 100);
        }
    };

    return result;
}