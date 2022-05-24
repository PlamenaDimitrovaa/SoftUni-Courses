const { expect } = require('chai');
const flowerShop = require('./flowerShop.js');

describe('Flower Shop', () => {

    describe('Test for calcPriceOfFlowers', () => {
        it('Check for invalid parameters', () => {
            expect(() => flowerShop.calcPriceOfFlowers('string', 'string', 'string').to.throw('Invalid input!'));
            expect(() => flowerShop.calcPriceOfFlowers(3, 3, 3).to.throw('Invalid input!'));
            expect(() => flowerShop.calcPriceOfFlowers(3, 'string', 3).to.throw('Invalid input!'));
            expect(() => flowerShop.calcPriceOfFlowers(3, 3, 'string').to.throw('Invalid input!'));
        });

        it('Check valid parameters', () => {
            expect(flowerShop.calcPriceOfFlowers('string', 3, 3)).to.equal(`You need $9.00 to buy string!`);
            expect(flowerShop.calcPriceOfFlowers('string', 4, 3)).to.equal(`You need $12.00 to buy string!`);
            expect(flowerShop.calcPriceOfFlowers('string', 0, 3)).to.equal(`You need $0.00 to buy string!`);

        });
    });

    describe('Test for checkFlowersAvailable', () => {
        it('Check valid parameters', () => {
            expect(flowerShop.checkFlowersAvailable('Rose', ['Rose', 'Orch', 'Lily'])).to.equal(`The Rose are available!`);
            expect(flowerShop.checkFlowersAvailable('Rose', ['Orch', 'Lily'])).to.equal(`The Rose are sold! You need to purchase more!`);
        });
    });

    describe('Test for sellFlowers', () => {
        it('Check for valid parameters', () => {
            expect(() => flowerShop.sellFlowers('string', 'string').to.throw('Invalid input!'));
            expect(() => flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 'string').to.throw('Invalid input!'));
            expect(() => flowerShop.sellFlowers('string', 2).to.throw('Invalid input!'));
            expect(() => flowerShop.sellFlowers('string', ['Rose', 'Orch', 'Lily']).to.throw('Invalid input!'));
            expect(() => flowerShop.sellFlowers(2, 2).to.throw('Invalid input!'));
        });

        it('Check for valid parameters', () => {
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 0)).to.equal(`Orch / Lily`);
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 1)).to.equal(`Rose / Lily`);
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 2)).to.equal(`Rose / Orch`);

        });
    });
});