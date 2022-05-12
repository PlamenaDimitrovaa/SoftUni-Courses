const createCalculator = require('./07.AddOrSubtract');
const expect = require('chai').expect;

describe('Add or Subtract checks', () => {
    it('Should return the correct input', () => {
        let calculator = createCalculator();
        calculator.add(3);
        let expectedNum = 3;
       expect(calculator.get()).to.be.equal(expectedNum);
    });

    it('Should return the correct input', () => {
        let calculator = createCalculator();
        calculator.subtract(3);
        let expectedNum = -3;
       expect(calculator.get()).to.be.equal(expectedNum);
    });

    it('Should return the correct input', () => {
        let calculator = createCalculator();
        calculator.add(3);
        calculator.subtract(3);
        let expectedNum = 0;
       expect(calculator.get()).to.be.equal(expectedNum);
    });

    it('Should return NaN if the input is not correct', () => {
        let calculator = createCalculator();
        calculator.add('Oreo');
       expect(calculator.get()).is.NaN;
    })
});