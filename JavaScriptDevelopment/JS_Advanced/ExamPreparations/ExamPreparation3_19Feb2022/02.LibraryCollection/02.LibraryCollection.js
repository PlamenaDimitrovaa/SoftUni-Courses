class LibraryCollection{
    constructor(capacity){
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor){
        if(this.capacity <= this.books.length){
            throw new Error("Not enough space in the collection.");
        }

        let currentBook = {
            bookName, 
            bookAuthor,
            payed: false,
        }

        this.books.push(currentBook);
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }

    payBook(bookName){
        let book = this.books.find(x => x.bookName == bookName);

        if(!book){
            throw new Error(`${bookName} is not in the collection.`);
        } else if(book.payed == true){
            throw new Error(`${bookName} has already been paid.`);
        } else{
            book.payed = true;
            return `${bookName} has been successfully paid.`;
        }
    }

    removeBook(bookName){
        let book = this.books.find(x => x.bookName == bookName);
        if(!book){
            throw new Error("The book, you're looking for, is not found.");
        } else if(book.payed == false){
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        } else{
            this.books = this.books.filter(x => x.bookName !== bookName);
            return `${bookName} remove from the collection.`;
        }
    }

    getStatistics(bookAuthor){
        if(!bookAuthor){
            let sortedBook = this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));
            let result = [];
            let emptySlots = this.capacity - this.books.length;
            result.push(`The book collection has ${ emptySlots } empty spots left.`);
            sortedBook.map((b) => {
                let paid = b.payed ? 'Has Paid' : 'Not Paid';
                result.push(`${b.bookName} == ${b.bookAuthor} - ${paid}.`);
            });
            return result.join('\n').trim();
        } else{

            let findBook = this.books.find(x => x.bookAuthor == bookAuthor);
                if(findBook){
                    let paid = findBook.payed ? 'Has Paid' : 'Not Paid';
                    let result = [];
                    result.push(`${findBook.bookName} == ${findBook.bookAuthor} - ${paid}.`);
                     return result.join('\n').trim();
                } else{
                    throw new Error(`${bookAuthor} is not in the collection.`);
                }    
        }
    } 
}