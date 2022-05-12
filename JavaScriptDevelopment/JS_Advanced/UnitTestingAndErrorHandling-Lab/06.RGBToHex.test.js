const rgbToHexColor = require('./06.RGBToHex');
const expect = require('chai').expect;

describe('Checks converter', () => {
    it("Should return undefined if the input is not correct", () => {
        expect(rgbToHexColor('pl', 9, 10)).to.be.undefined;
        expect(rgbToHexColor(-8, 9, 10)).to.be.undefined;
        expect(rgbToHexColor(300, 9, 10)).to.be.undefined;

        expect(rgbToHexColor(9, 'pl', 10)).to.be.undefined;
        expect(rgbToHexColor(9, -8, 10)).to.be.undefined;
        expect(rgbToHexColor(9, 300, 10)).to.be.undefined;

        expect(rgbToHexColor(9, 10, 'pl')).to.be.undefined;
        expect(rgbToHexColor(9, 10, -10)).to.be.undefined;
        expect(rgbToHexColor(9, 10, 300)).to.be.undefined;
    })

    it('Should return white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    });

    it('Should return black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });

    it('Should return pink', () => {
        expect(rgbToHexColor(255,192,203)).to.be.equal('#FFC0CB');
    });
});