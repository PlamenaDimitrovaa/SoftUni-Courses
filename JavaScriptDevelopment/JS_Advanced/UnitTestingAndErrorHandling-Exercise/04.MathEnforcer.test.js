const mathEnforcer = require('./04.MathEnforcer');
const expect = require('chai').expect;

describe("Math Enforcer Checker", () => {
    it('Should Return Undefined', () => {
       expect(mathEnforcer.addFive('pl')).to.be.undefined;
    });

    it('Should Return Undefined', () => {
        expect(mathEnforcer.addFive([])).to.be.undefined;
    });

    it('Should Return Correct Answer For Add Function', () => {
        expect(mathEnforcer.addFive(5)).to.be.equal(10);
    });

    it('Should Return Correct Answer For Add Function', () => {
        expect(mathEnforcer.addFive(3.5)).to.be.closeTo(8.5, 0.01);
    });

     it('Should Return Correct Answer For Add Function', () => {
        expect(mathEnforcer.addFive(-5)).to.be.equal(0);
    });

    it('Should Return Undefined', () => {
      expect(mathEnforcer.subtractTen('pl')).to.be.undefined;
    });
 
    it('Should Return Undefined', () => {
      expect(mathEnforcer.subtractTen([])).to.be.undefined;
    });

    it('Should Return Correct Answer For Subtract Function', () => {
        expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
    });

    it('Should Return Correct Answer For Subtract Function', () => {
        expect(mathEnforcer.subtractTen(12.5)).to.be.closeTo(2.5, 0.01);
    });

    it('Should Return Correct Answer For Subtract Function', () => {
        expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
    });

    it('Should Return Undefined', () => {
        expect(mathEnforcer.sum('pl', 5)).to.be.undefined;
      });
   
    it('Should Return Undefined', () => {
        expect(mathEnforcer.sum(5, 'bo')).to.be.undefined;
    });
  
    it('Should Return Correct Answer For Sum Function', () => {
        expect(mathEnforcer.sum(20, 30)).to.be.equal(50);
    });

    it('Should Return Correct Answer For Sum Function', () => {
        expect(mathEnforcer.sum(-5, - 20)).to.be.equal(-25);
    });

    it('Should Return Correct Answer For Sum Function', () => {
        expect(mathEnforcer.sum(3.5, 7.2)).to.be.closeTo(10.7, 0.01);
    });
});