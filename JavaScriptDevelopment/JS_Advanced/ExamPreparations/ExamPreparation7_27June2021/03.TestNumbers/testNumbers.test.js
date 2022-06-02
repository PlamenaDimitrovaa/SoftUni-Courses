let testNumbers = require('./testNumbers.js');
let expect = require('chai').expect;

describe('Test Numbers Tests', () =>{
    describe("sum numbers", () => {
        it("sum numbers should accept the correct parameters", () => {
            expect(testNumbers.sumNumbers('pl', 5)).to.equals(undefined);
        })

        it("sum numbers should accept the correct parameters", () => {
            expect(testNumbers.sumNumbers(5, 'pl')).to.equals(undefined);
        })

        it("sum numbers should accept the correct parameters", () => {
            expect(testNumbers.sumNumbers('pl', 'bo')).to.equals(undefined);
        })

        it("sum numbers should work correct", () => {
            expect(testNumbers.sumNumbers(5, 5)).to.equals('10.00');
        })

        it("sum numbers should work correct", () => {
            expect(testNumbers.sumNumbers(5, 15)).to.equals('20.00');
        })
    })

    describe("Number Checjer", () => {
        it("numberChecker should accept the correct parameters", () => {
            expect(() => testNumbers.numberChecker(NaN)).to.throws(Error, "The input is not a number!");
        })

        it("numberChecker should accept the correct parameters", () => {
            expect(() => testNumbers.numberChecker('bo')).to.throws(Error, "The input is not a number!");
        })

        it("numberChecker should work correct", () => {
            expect(testNumbers.numberChecker(4)).to.equals('The number is even!');
        })

        it("numberChecker should work correct", () => {
            expect(testNumbers.numberChecker(3)).to.equals('The number is odd!');
        })
    })

    describe("Average Sum Array", () => {
        it("Average Sum Array should work correct", () => {
            expect(testNumbers.averageSumArray([1,2,3,4,5])).to.equals(3);
        })

        it("Average Sum Array should work correct", () => {
            expect(testNumbers.averageSumArray([1,2,3])).to.equals(2);
        })
    })
})