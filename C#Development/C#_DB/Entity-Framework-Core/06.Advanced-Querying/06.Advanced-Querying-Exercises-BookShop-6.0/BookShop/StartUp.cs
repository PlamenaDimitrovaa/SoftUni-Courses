namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);
            // string ageRestrictionInput = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
           // string input = Console.ReadLine();
            //int length = int.Parse(Console.ReadLine());
            string result = GetMostRecentBooks(dbContext);
            Console.WriteLine(result);
        }

        //2
        public static string GetBooksByAgeRestriction(BookShopContext dbContext, string command)
        {
            //bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObj);

            //AgeRestriction ageRestriction;

            //if (hasParsed) 
            //{
            //    ageRestriction = (AgeRestriction)ageRestrictionObj;

            //    string[] bookTitles = dbContext.Books
            //        .Where(b => b.AgeRestriction == ageRestriction)
            //        .OrderBy(b => b.Title)
            //        .Select(b => b.Title)
            //        .ToArray();

            //    return string.Join(Environment.NewLine, bookTitles);
            //}

            //return null;

            //Second solution
            try
            {
                AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);
                string[] bookTitles = dbContext.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

                return string.Join(Environment.NewLine, bookTitles);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //3
        public static string GetGoldenBooks(BookShopContext dbContext)
        {
            string[] bookTitles = dbContext.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //4
        public static string GetBooksByPrice(BookShopContext dbContext)
        {
            var bookTitles = dbContext.Books
                .Where(b => b.Price > 40)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var item in bookTitles)
            {
                sb.AppendLine($"{item.Title} - ${item.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //5
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        //6
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            string[] books = context.Books
                .Where(b => b.BookCategories
                        .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        //7
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value < targetDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate.Value
                })
                .OrderByDescending(b => b.Value)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in bookTitles)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //8
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        //9
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

           return string.Join(Environment.NewLine, books);
        }

        //10
         public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksWithAuthors = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var book in booksWithAuthors)
            {
                sb.AppendLine($"{book.Title} ({book.FirstName} {book.LastName})");
            }

            return sb.ToString().TrimEnd();
        }

        //11
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Select(b => b.Title.Length)
                .ToArray();

            return books.Length;
        }

        //12
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    TotalCopies = a.Books.Sum(b => b.Copies),
                    a.FirstName,
                    a.LastName
                })
                .OrderByDescending(b => b.TotalCopies)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        //13
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(p => p.Book.Price * p.Book.Copies),
                })
                .OrderByDescending(p => p.TotalProfit)
                .ThenBy(p => p.Name)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //14
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .Select(x => new
                {
                    CategoryName = x.Name,
                    Books = x.CategoryBooks.Select(c => new
                    {
                        c.Book.Title,
                        c.Book.ReleaseDate.Value
                    })
                    .OrderByDescending(b => b.Value)
                    .Take(3)
                    .ToArray()
                })
                .OrderBy(x => x.CategoryName)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var category in categoryBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //15
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
              .Where(x => x.ReleaseDate.Value.Year < 2010)
              .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //16
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();
            return books.Count;
        }
    }
}


