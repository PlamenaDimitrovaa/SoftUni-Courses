let bookSelection = require('./bookSelection.js');
let expect = require('chai').expect;

describe("Book Selection Tests", () => {
    describe("Is Genre Suitable", () =>{
        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Thriller", 6)).to.equals(`Books with Thriller genre are not suitable for kids at 6 age`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Thriller", 12)).to.equals(`Books with Thriller genre are not suitable for kids at 12 age`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Horror", 6)).to.equals(`Books with Horror genre are not suitable for kids at 6 age`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Horror", 12)).to.equals(`Books with Horror genre are not suitable for kids at 12 age`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Horror", 13)).to.equals(`Those books are suitable`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Thriller", 15)).to.equals(`Those books are suitable`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Barbie", 5)).to.equals(`Those books are suitable`);
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(bookSelection.isGenreSuitable("Barbie", 15)).to.equals(`Those books are suitable`);
        })
    })

    describe("isItAffordableTests", () => {
        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(() => bookSelection.isItAffordable('pl', 5)).to.throw(Error, 'Invalid input');
        })

        it("IsGenreSuitable should accept the correct parameters", () => {
            expect(() => bookSelection.isItAffordable(5, '5')).to.throw(Error, 'Invalid input');
        })

        it("IsGenreSuitable work correct", () => {
            expect(bookSelection.isItAffordable(5, 5)).to.equals(`Book bought. You have 0$ left`);
        })

        it("IsGenreSuitable work correct", () => {
            expect(bookSelection.isItAffordable(5, 10)).to.equals(`Book bought. You have 5$ left`);
        })

        it("IsGenreSuitable work correct", () => {
            expect(bookSelection.isItAffordable(5, 3)).to.equals("You don't have enough money");
        })

        it("IsGenreSuitable work correct", () => {
            expect(bookSelection.isItAffordable(5, 0)).to.equals("You don't have enough money");
        })
    })

    describe("Suitable Titles Tests", () => {
        it("suitableTitles should accept the correct parameters", () => {
            expect(() => bookSelection.suitableTitles('pl', 'pl')).to.throw(Error, 'Invalid input');
        })  

        it("suitableTitles should accept the correct parameters", () => {
            expect(() => bookSelection.suitableTitles(['pl', 'bo'], 5)).to.throw(Error, 'Invalid input');
        }) 

        it("suitableTitles should work correct", () => {
            expect(bookSelection.suitableTitles([{title: 'pl', genre: 'horror'}], 'horror')).to.deep.equal([ 'pl' ]);
        }) 

        it("suitableTitles should work correct", () => {
            expect(bookSelection.suitableTitles([{title: 'bo', genre: 'thriller'}], 'thriller')).to.deep.equal([ 'bo' ]);
        }) 
    })
})