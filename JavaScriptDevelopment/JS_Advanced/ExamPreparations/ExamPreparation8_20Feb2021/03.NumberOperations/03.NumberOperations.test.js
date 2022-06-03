let numberOperations = require('./03.NumberOperations.js');
let expect = require('chai').expect;

describe("Number Operations Tests", () => {
    describe("Pow numbers", () => {
        it("Pow numbers should work correct", () => {
            expect(numberOperations.powNumber(2)).to.equals(4);
        })

        it("Pow numbers should work correct", () => {
            expect(numberOperations.powNumber(5)).to.equals(25);
        })
    })

    describe("Number Checker", () => {
        it("Number Checker should accept the correct parameters", () => {
            expect(() => numberOperations.numberChecker(NaN)).to.throw(Error, 'The input is not a number!');
        })

        it("Number Checker should accept the correct parameters", () => {
            expect(() => numberOperations.numberChecker('pl')).to.throw(Error, 'The input is not a number!');
        })

        it("Number Checker should work correct", () => {
            expect(numberOperations.numberChecker(99)).to.equals('The number is lower than 100!');
        })

        it("Number Checker should work correct", () => {
            expect(numberOperations.numberChecker(100)).to.equals('The number is greater or equal to 100!');
        })

        it("Number Checker should work correct", () => {
            expect(numberOperations.numberChecker(103)).to.equals('The number is greater or equal to 100!');
        })
    })

    describe("Sum Arrays", () => {
        it("Sum arrays should work correct", () => {
            expect(numberOperations.sumArrays([1,2,3], [1,2,3])).to.deep.equal([2,4,6]);
        })

        it("Sum arrays should work correct", () => {
            expect(numberOperations.sumArrays([1,2,3], [1,2])).to.deep.equal([2,4,3]);
        })
    })
})