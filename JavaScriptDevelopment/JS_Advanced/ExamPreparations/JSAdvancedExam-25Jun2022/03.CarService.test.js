let carService = require('./03.CarService.js');
let expect = require('chai').expect;

describe('Car Service Tests', () => {
    describe('Is It Expensive Tests', () => {
        it('Is it expensive should work correct', () => {
            expect(carService.isItExpensive('Engine')).to.equals(`The issue with the car is more severe and it will cost more money`);
        })

        it('Is it expensive should work correct', () => {
            expect(carService.isItExpensive('Transmission')).to.equals(`The issue with the car is more severe and it will cost more money`);
        })

        it('Is it expensive should work correct', () => {
            expect(carService.isItExpensive('Something else')).to.equals(`The overall price will be a bit cheaper`);
        })

        it('Is it expensive should work correct', () => {
            expect(carService.isItExpensive()).to.equals(`The overall price will be a bit cheaper`);
        })
    })

    describe('Discount Tests', () => {
        it('Discount should accept the correct parameters', () => {
            expect(() => carService.discount('pl', 5)).to.throw(Error, 'Invalid input');
        })

        it('Discount should accept the correct parameters', () => {
            expect(() => carService.discount(5, '5')).to.throw(Error, 'Invalid input');
        })

        it('Discount should accept the correct parameters', () => {
            expect(() => carService.discount(5)).to.throw(Error, 'Invalid input');
        })

        it('Discount should accept the correct parameters', () => {
            expect(() => carService.discount()).to.throw(Error, 'Invalid input');
        })

        it('Discount should work correct', () => {
            expect(carService.discount(3, 50)).to.equals(`Discount applied! You saved 7.5$`);
        })

        it('Discount should work correct', () => {
            expect(carService.discount(7, 30)).to.equals(`Discount applied! You saved 4.5$`);
        })

        it('Discount should work correct', () => {
            expect(carService.discount(5, 60)).to.equals(`Discount applied! You saved 9$`);
        })

        it('Discount should work correct', () => {
            expect(carService.discount(8, 60)).to.equals(`Discount applied! You saved 18$`);
        })

        it('Discount should work correct', () => {
            expect(carService.discount(10, 100)).to.equals(`Discount applied! You saved 30$`);
        })

        it('Discount should work correct', () => {
            expect(carService.discount(1, 100)).to.equals("You cannot apply a discount");
        })

        it('Discount should work correct', () => {
            expect(carService.discount(0, 100)).to.equals("You cannot apply a discount");
        })

        it('Discount should work correct', () => {
            expect(carService.discount(-1, 100)).to.equals("You cannot apply a discount");
        })
    })

    describe('Parts to buy Tests', () => {
        it('Parts to Buy should accept the correct parameters', () => {
            expect(() => carService.partsToBuy(['light', 'door'], 'pl')).to.throw(Error, 'Invalid input');
        })

        it('Parts to Buy should accept the correct parameters', () => {
            expect(() => carService.partsToBuy('pl', ['light', 'door'])).to.throw(Error, 'Invalid input');
        })

        it('Parts to Buy should accept the correct parameters', () => {
            expect(() => carService.partsToBuy()).to.throw(Error, 'Invalid input');
        })

        it('Parts to Buy should accept the correct parameters', () => {
            expect(() => carService.partsToBuy(['light', 'door'])).to.throw(Error, 'Invalid input');
        })

        it('Parts to Buy should work correct', () => {
            expect(carService.partsToBuy([{'part': 'light', 'price': 4}, {'part': 'door', 'price': 2}], ['light', 'paint'])).to.equals(4);
        })

        it('Parts to Buy should work correct', () => {
            expect(carService.partsToBuy([{'part': 'light', 'price': 100}, {'part': 'door', 'price': 2}], ['light', 'paint', 'door'])).to.equals(102);
        })

        it('Parts to Buy should work correct', () => {
            expect(carService.partsToBuy([{'part': 'light', 'price': 100}, {'part': 'door', 'price': 2}], ['paint'])).to.equals(0);
        })  
    })
})

// partsToBuy(partsCatalog, neededParts) {
//     let totalSum = 0;

//     if (!Array.isArray(partsCatalog) || !Array.isArray(neededParts)) {
//       throw new Error("Invalid input");
//     }
//     neededParts.forEach((neededPart) => {
//       partsCatalog.map((obj) => {
//         if (obj.part === neededPart) {
//           totalSum += obj.price;
//         }
//       });
//     });

//     return totalSum;
//   },
// };