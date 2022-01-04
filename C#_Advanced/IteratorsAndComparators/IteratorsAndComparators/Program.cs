using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var library = new Library();
            //library.Add(new Book("Don Quixote", 1605, new List<string>() { "Miguel de Cervantes"}));
            //library.Add(new Book("Lord of the Rings", 1954, new List<string>() { "Tolkien" }));
            //library.Add(new Book("Harry Potter", 1997, new List<string>() { "J.K. Rowling" }));
            //library.Add(new Book("And Then There Were None", 1939, new List<string>() { "Agatha Christie" }));
            //library.Add(new Book("The Twelve Chairs", 1928, new List<string>() { "Ilya Ilf", "Yevgeny Petrov" }));

            //foreach (var book in library)
            //{
            //    Console.WriteLine($"{string.Join("&",book.Authors)}, {book.Title}, {book.Year} ");
            //}

            Book bookOne = new Book(" Animal Farm", 2003, " George Orwell");
            Book bookTwo = new Book(" The Documents in the Case", 2002, " Dorothy Sayers", " Robert Eustace");
            Book bookThree = new Book(" The Documents in the Case", 1930);
            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
