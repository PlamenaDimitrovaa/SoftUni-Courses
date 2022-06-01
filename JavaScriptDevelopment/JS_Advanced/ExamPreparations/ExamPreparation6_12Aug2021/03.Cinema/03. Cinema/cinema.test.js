let cinema = require('./cinema.js');
let expect = require('chai').expect;

describe("Cinema Tests", () => {
    describe("Show Movies Tests", () => {
        it("Show Movies should accept the correct parameters", () => {
            expect(cinema.showMovies([])).to.equals('There are currently no movies to show.');
        })

        it("Show Movies should work correct", () => {
            expect(cinema.showMovies(["San Andreas", "Vice City", "The dog"])).to.equals('San Andreas, Vice City, The dog');
        })

        it("Show Movies should work correct", () => {
            expect(cinema.showMovies(["San Andreas"])).to.equals('San Andreas');
        })
    })

    describe("Ticket Price Tests", () => {
        it("Ticket Price should accept the correct parameters", () => {
            expect(() => cinema.ticketPrice("Pl")).to.throw(Error, 'Invalid projection type.');
        })

        it("Ticket Price should work correct", () => {
            expect(cinema.ticketPrice("Premiere")).to.equals(12.00);
        })

        it("Ticket Price should work correct", () => {
            expect(cinema.ticketPrice("Normal")).to.equals(7.50);
        })

        it("Ticket Price should work correct", () => {
            expect(cinema.ticketPrice("Discount")).to.equals(5.50);
        })
    })

    describe("Swap Seats In Hall Tests",() => {
        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall('pl', 5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall()).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(0, 5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(-3, 5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(21, 5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5, 'pl')).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall('pl', 'pl')).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(0, -1)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(-5, -8)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(30, 30)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(20, 30)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5, 0)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5, -3)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5, 21)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should accept the correct parameters", () =>{
            expect(cinema.swapSeatsInHall(5, 5)).to.equals("Unsuccessful change of seats in the hall.");
        })

        it("swapSeatsInHall should work correct", () =>{
            expect(cinema.swapSeatsInHall(3, 5)).to.equals("Successful change of seats in the hall.");
        })

        it("swapSeatsInHall should work correct", () =>{
            expect(cinema.swapSeatsInHall(5, 20)).to.equals("Successful change of seats in the hall.");
        })
    })
})