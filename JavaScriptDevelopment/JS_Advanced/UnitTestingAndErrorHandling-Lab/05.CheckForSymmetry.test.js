const isSymmetric = require('./05.CheckForSymmetry');
const expect = require('chai').expect;

describe('Checks for Symmetry', () => {

    it('Should return true if input array is symmetric', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('Should return false if the input is an object', () => {
        expect(isSymmetric({})).to.be.false;
    })

    it('Should return false if the input is a string', () => {
        expect(isSymmetric('someString')).to.be.false;
    })

     it('Should return false for type-coersed elements', () => {
        expect(isSymmetric([1, '1'])).to.be.false;
    });

    it('Should return false if the input is a number', () => {
        expect(isSymmetric(3)).to.be.false;
    })

    it('Should return true if the array is symetric', () => {
        let array = [1, 2, 1];
        expect(isSymmetric(array)).to.be.true;
    })

    it('Should return false if the array is not symetric', () => {
        let array = [1, 2, 2];
        expect(isSymmetric(array)).to.be.false;
    })
})