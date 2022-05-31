let library = require('./library.js');
let expect = require('chai').expect;

describe("Library Tests", () => {
    describe("calc price of book tests", () => {
        it('calc price of book should throw an error for invalid parameters', () =>{
            expect(() => library.calcPriceOfBook(5, 2002)).to.throw(Error, "Invalid input");
        })

        it('calc price of book should throw an error for invalid parameters', () =>{
            expect(() => library.calcPriceOfBook("The noticer", 'Pl')).to.throw(Error, "Invalid input");
        })

        it('calc price of book should work correct', () =>{
            expect(library.calcPriceOfBook("The noticer", 1980)).to.equals("Price of The noticer is 10.00");
        })

        it('calc price of book should work correct', () =>{
            expect(library.calcPriceOfBook("The noticer", 1960)).to.equals("Price of The noticer is 10.00");
        })

        it('calc price of book should work correct', () =>{
            expect(library.calcPriceOfBook("The noticer", 1982)).to.equals("Price of The noticer is 20.00");
        })
    })

    describe('find book', () => {
        it('find book should throw an error for invalid parameters', () => {
            expect(() => library.findBook([], 'Alice')).to.throw(Error, "No books currently available");
        })

        it('find book should work correct', () => {
            expect(library.findBook(['Alice'], 'Alice')).to.equals("We found the book you want.");
        })

        it('find book should work correct', () => {
            expect(library.findBook(['The noticer', 'Oreo world'], 'Alice')).to.equals("The book you are looking for is not here!");
        })
    })

    describe('arrange the books', () => {
        it('arrange books should throw an error for invalid parameters', () => {
            expect(() => library.arrangeTheBooks('pl')).to.throw(Error, "Invalid input");
        })

        it('arrange books should throw an error for invalid parameters', () => {
            expect(() => library.arrangeTheBooks(-3)).to.throw(Error, "Invalid input");
        })

        it('arrange books should work correct', () => {
            expect(library.arrangeTheBooks(40)).to.equals("Great job, the books are arranged.");
        })

        it('arrange books should work correct', () => {
            expect(library.arrangeTheBooks(30)).to.equals("Great job, the books are arranged.");
        })

        it('arrange books should work correct', () => {
            expect(library.arrangeTheBooks(50)).to.equals("Insufficient space, more shelves need to be purchased.");
        })
    })
})