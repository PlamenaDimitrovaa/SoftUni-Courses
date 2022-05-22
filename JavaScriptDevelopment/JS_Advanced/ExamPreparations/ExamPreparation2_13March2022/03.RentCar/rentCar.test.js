let expect = require('chai').expect;
let rentCar = require("./rentCar.js");

describe('Rent car tests', () => {
    describe('Search function', () => {
        it('Rent car should have the correct properties', () => {
            expect(rentCar).to.have.property('searchCar');
            expect(rentCar).to.have.property('calculatePriceOfCar');
            expect(rentCar).to.have.property('checkBudget');
        })

        it('Search Car should throw error', () => {
            expect(() => rentCar.searchCar(['Audi', 'BMW'], 'car')).to.throw(Error, 'There are no such models in the catalog!');
        })

        it('Search car should throw an error for invalid parameters', () => {
            expect(() => rentCar.searchCar().to.throw(Error, 'Invalid input!'));
        })

        it('Search car should throw an error for not correct parameters', () => {
            expect(() => rentCar.searchCar('car', []).to.throw(Error, 'Invalid input!'));
            expect(() => rentCar.searchCar([], 5).to.throw(Error, 'Invalid input!'));
            expect(() => rentCar.searchCar(5, 'car').to.throw(Error, 'Invalid input!'));
            expect(() => rentCar.searchCar('tupy', 5).to.throw(Error, 'Invalid input!'));
        })

        it('Search car should return a message for count of existing car', () => {
            expect(() => rentCar.searchCar(['Audi', 'Mercedes', 'Audi'], 'Audi').to.equals(`There is 2 car of model Audi in the catalog!`));
        })

        it('Search car should return a message for count of existing car', () => {
            expect(() => rentCar.searchCar(['Audi', 'Mercedes', 'Audi'], 'Mercedes').to.equals(`There is 1 car of model Mercedes in the catalog!`));
        })
    })

    describe('Calculate Price Of Car', () => {
        it('Calculate should work correct', () => {
            expect(() => rentCar.calculatePriceOfCar('Volkswagen', 2).to.equals(`You choose Volkswagen and it will cost $40!`));
        })
        it('Calculate should work correct', () => {
            expect(() => rentCar.calculatePriceOfCar('Mercedes', 1).to.equals(`You choose Mercedes and it will cost $50!`));
        })
        it('Calculate should work correct', () => {
            expect(() => rentCar.calculatePriceOfCar('Audi', 2).to.equals(`You choose Audi and it will cost $72!`));
        })
        it('Calculate should work correct', () => {
            expect(() => rentCar.calculatePriceOfCar('BMW', 2).to.equals(`You choose BMW and it will cost $90!`));
        })
        it('Calculate should work correct', () => {
            expect(() => rentCar.calculatePriceOfCar('Toyota', 1).to.equals(`You choose BMW and it will cost $40!`));
        })

        it('Calculate should throw an error if there is no such car in the catalog', () => {
            expect(() => rentCar.calculatePriceOfCar('Car', 2).to.throw(Error, 'No such model in the catalog!'));
        })

        it('Calculate should throw an error for invalid parameters', () => {
            expect(() => rentCar.calculatePriceOfCar(2, 2).to.throw(Error, 'Invalid input!'));
        })

        it('Calculate should throw an error for invalid parameters', () => {
            expect(() => rentCar.calculatePriceOfCar('no', 'no').to.throw(Error, 'Invalid input!'));
        })
    })

    describe('Check Budget', () => {
        it('Check should work correct', () => {
           expect(() => rentCar.checkBudget(5, 2, 20).to.equals(`You rent a car!`));
        })

        it('Check should work correct', () => {
            expect(() => rentCar.checkBudget(5, 2, 10).to.equals(`You rent a car!`));
         })

        it('Check should throw an error for invalid parameters', () => {
            expect(() => rentCar.checkBudget('no', 2, 20).to.throw(Error, 'Invalid input!'));
         })

         it('Check should throw an error for invalid parameters', () => {
            expect(() => rentCar.checkBudget(2, 'no', 20).to.throw(Error, 'Invalid input!'));
         })

         it('Check should throw an error for invalid parameters', () => {
            expect(() => rentCar.checkBudget(2, 2, 'no').to.throw(Error, 'Invalid input!'));
         })

         it('Check if budget is enough', () => {
            expect(() => rentCar.checkBudget(5, 10, 20).to.equals('You need a bigger budget!'));
         })
    })
})