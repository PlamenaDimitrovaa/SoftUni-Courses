let expect = require('chai').expect;
let flowerShop = require('./flowerShop.js');

describe('Flower Shop Tests', () => {
    describe('calcPriceOfFlowers', () => {
        it('calcPriceOfFlowers should accept only the correct parameters', () => {
            expect(() => flowerShop.calcPriceOfFlowers(1, 2, 3)).to.throw(Error, 'Invalid input!');
        })

        it('calcPriceOfFlowers should accept only the correct parameters', () => {
            expect(() => flowerShop.calcPriceOfFlowers('string', [], 3)).to.throw(Error, 'Invalid input!');
        })

        it('calcPriceOfFlowers should accept only the correct parameters', () => {
            expect(() => flowerShop.calcPriceOfFlowers('string', 2, 'bo')).to.throw(Error, 'Invalid input!');
        })

        it('calcPriceOfFlowers should work correct', () => {
            expect(flowerShop.calcPriceOfFlowers('flower', 2, 3)).to.equals(`You need $6.00 to buy flower!`);
            expect(flowerShop.calcPriceOfFlowers('flower2', 8, 5)).to.equals(`You need $40.00 to buy flower2!`);
            expect(flowerShop.calcPriceOfFlowers('flower3', 22, 3)).to.equals(`You need $66.00 to buy flower3!`);
        })
    })

    describe('checkFlowersAvailable', () => {
        it('checkFlowersAvailable should accept correct parameters', () => {
            expect(flowerShop.checkFlowersAvailable('roses', ['roses', 'tuples', 'lilacs'])).to.equals(`The roses are available!`);
            expect(flowerShop.checkFlowersAvailable('tuples', ['tuples', 'lilacs'])).to.equals(`The tuples are available!`);
            expect(flowerShop.checkFlowersAvailable('lilacs', ['roses', 'lilacs'])).to.equals(`The lilacs are available!`);
        })

        it('calcPriceOfFlowers should work correct', () => {
            expect(flowerShop.checkFlowersAvailable('rose', ['roses', 'tulips'])).to.equals(`The rose are sold! You need to purchase more!`);
            expect(flowerShop.checkFlowersAvailable('tuples', [])).to.equals(`The tuples are sold! You need to purchase more!`);
        })
    })

    describe('SellFlowers', () => {
        it('sellFlowers should accept only correct parameters', () =>{
            expect(() => flowerShop.sellFlowers('pl', 5)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['pl'], 'bo')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['pl'], -8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['pl', 'bo'], 6)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['pl'], 1)).to.throw(Error, 'Invalid input!');
        })

        it('sellFlowers should work correct', () => {
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 0)).to.equal(`Orch / Lily`);
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 1)).to.equal(`Rose / Lily`);
            expect(flowerShop.sellFlowers(['Rose', 'Orch', 'Lily'], 2)).to.equal(`Rose / Orch`);
        })
    })
})
