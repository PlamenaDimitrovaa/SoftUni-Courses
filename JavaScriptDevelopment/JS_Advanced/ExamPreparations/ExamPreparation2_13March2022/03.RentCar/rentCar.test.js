let rentCar = require('./rentCar.js');
let expect = require('chai').expect;

describe('Rent Car Tests', () => {
    describe('SearchCar Tests', () => {
        it('search car should throw error for invalid input', () => {
            expect(() => rentCar.searchCar("Pl", "Pl")).to.throw(Error, 'Invalid input!');
        })

        it('search car should throw error for invalid input', () => {
            expect(() => rentCar.searchCar(['Audi', 'BMW'], 5)).to.throw(Error, 'Invalid input!');
        })
    })

    describe('SearchCar Tests', () => {
        it('search car should throw error for invalid car', () => {
            expect(() => rentCar.searchCar([], "Pl")).to.throw(Error, 'There are no such models in the catalog!');
        })

        it('search car should throw error for invalid car', () => {
            expect(() => rentCar.searchCar(['BMW', 'Audi'], "Pl")).to.throw(Error, 'There are no such models in the catalog!');
        })
    })

    describe('SearchCar Tests', () => {
        it('search car should work correct', () => {
            expect(rentCar.searchCar(['Audi', 'BMW', 'Mercedes'], 'Audi')).to.equals(`There is 1 car of model Audi in the catalog!`);
        })
    })

    describe("Calculate Price Of Car", () => {
        it("It should throw an error for invalid input", ()=>{
            expect(() => rentCar.calculatePriceOfCar(5, 5)).to.throw(Error, 'Invalid input!');
        })

        it("It should throw an error for invalid input", ()=>{
            expect(() => rentCar.calculatePriceOfCar('pl', 'pl')).to.throw(Error, 'Invalid input!');
        })

        it("It should throw an error if the car doesnt exists", ()=>{
            expect(() => rentCar.calculatePriceOfCar('pl', 5)).to.throw(Error, 'No such model in the catalog!');
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('Volkswagen', 5)).to.equals(`You choose Volkswagen and it will cost $100!`);
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('Audi', 2)).to.equals(`You choose Audi and it will cost $72!`);
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('Toyota', 3)).to.equals(`You choose Toyota and it will cost $120!`);
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('BMW', 1)).to.equals(`You choose BMW and it will cost $45!`);
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('Mercedes', 5)).to.equals(`You choose Mercedes and it will cost $250!`);
        })

        it("It should work correct", ()=>{
            expect(rentCar.calculatePriceOfCar('Mercedes', 0)).to.equals(`You choose Mercedes and it will cost $0!`);
        })
    })

    describe("Check Budget Tests", () => {
        it("It should throw an error for invalid input", () =>{
            expect(() => rentCar.checkBudget('Pl', 5, 20)).to.throw(Error, 'Invalid input!');
        })

        it("It should throw an error for invalid input", () =>{
            expect(() => rentCar.checkBudget(5, 'pl', 20)).to.throw(Error, 'Invalid input!');
        })

        it("It should throw an error for invalid input", () =>{
            expect(() => rentCar.checkBudget(4, 5, 'pl')).to.throw(Error, 'Invalid input!');
        })

        it("It should work correct", () =>{
            expect(rentCar.checkBudget(5, 5, 20)).to.equals('You need a bigger budget!');
        })

        it("It should work correct", () =>{
            expect(rentCar.checkBudget(2, 5, 20)).to.equals('You rent a car!');
        })

        it("It should work correct", () =>{
            expect(rentCar.checkBudget(2, 10, 20)).to.equals('You rent a car!');
        })
    })
})
