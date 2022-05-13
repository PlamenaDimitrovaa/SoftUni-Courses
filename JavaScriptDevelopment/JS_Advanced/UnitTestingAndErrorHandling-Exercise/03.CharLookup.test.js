const lookupChar = require('./03.CharLookup');
const expect = require('chai').expect;

describe("Char Checker", () => {
    it("Should Return Undefined", () => {
        expect(lookupChar([], 5)).to.be.undefined;
    });

    it("Should Return Undefined", () => {
        expect(lookupChar('kaka', 5.2)).to.be.undefined;
    });

    it("Should Return Undefined", () => {
        expect(lookupChar(8, 'kaka')).to.be.undefined;
    });

    it("Should Return Undefined", () => {
        expect(lookupChar('pl', 'bo')).to.be.undefined;
    });

    it("Should Return Incorrect index", () => {
        expect(lookupChar('Plamena', -9)).to.be.equal("Incorrect index");
    });

    it("Should Return Incorrect index", () => {
        expect(lookupChar('Plamena', 20)).to.be.equal("Incorrect index");
    });

    it("Should Return Incorrect index", () => {
        expect(lookupChar('Plamena', 7)).to.be.equal("Incorrect index");
    });

    it("Should Return Incorrect index", () => {
        expect(lookupChar('Plamena', -1)).to.be.equal("Incorrect index");
    });

    it("Should Work Correct", () => {
        expect(lookupChar('Plamena', 3)).to.be.equal("m");
    });

    it("Should Work Correct", () => {
        expect(lookupChar('012345', 1)).to.be.equal("1");
    });
});