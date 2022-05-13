const isOddOrEven = require('./02.EvenOrOdd');
const expect = require('chai').expect;

describe("Even or Odd Checker", () => {
    it("Should Return Undefined", () => {
        expect(isOddOrEven(5)).to.be.undefined;
    });

    it("Should Return Undefined", () => {
        expect(isOddOrEven([1,2,3])).to.be.undefined;
    });

    it("Should Return Even", () =>{
        expect(isOddOrEven('even')).to.be.equal('even');
    })

    it("Should Return Odd", () =>{
        expect(isOddOrEven('odd')).to.be.equal('odd');
    })
});