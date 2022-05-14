function solve(array, criteria){

    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let result = [];

    for (const ar of array) {
        let[destination, price, status] = ar.split('|');
        let currentTicket = new Ticket(destination, Number(price), status);
        result.push(currentTicket);
    }

    return result.sort((a, b) => criteria !== 'price' ? a[criteria].localeCompare(b[criteria]) : a[criteria] - b[criteria]);
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));