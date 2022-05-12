const expect = require('chai').expect;
const sum = require('./04.SumOfNumbers');

describe("Sum of Numbers", () => {
    it("TheSumShouldBeCorrectWithZeroes", () => {
        let numbers = [0,0,0,0];
        let expectedSum = 0;
        let actualSum = sum(numbers);
        expect(expectedSum).to.equal(actualSum);
    })

    it("TheSumShouldBeCorrectWithOneNumber", () => {
        let numbers = [3];
        let expectedSum = 3;
        let actualSum = sum(numbers);
        expect(expectedSum).to.equal(actualSum);
    })

    it("TheSumShouldBeCorrectWithSomeNumbers", () => {
        let numbers = [1,2,3,4,5];
        let expectedSum = 15;
        let actualSum = sum(numbers);
        expect(expectedSum).to.equal(actualSum);
    })
})