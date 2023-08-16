using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;
using Library.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.Url,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = decimal.Parse(model.Rating)
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await this.context
                .UsersBooks.AnyAsync(ub => ub.CollectorId == userId);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id,
                };

                await context.UsersBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(int id, EditBookViewModel model)
        {
            var book = await context.Books.FindAsync(id);

            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.ImageUrl = model.Url;
                book.Description = model.Description;
                book.CategoryId = model.CategoryId;
                book.Rating = decimal.Parse(model.Rating);

                await context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AllBookViewModel>> GetAll()
        {
            return await this.context.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Author = b.Author,
                    Category = b.Category.Name,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                })
                .ToListAsync();
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            return await this.context.Books
                .Where(b => b.Id == id)
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    CategoryId = b.CategoryId,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Title = b.Title,
                    Description = b.Description,
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EditBookViewModel?> GetBookByIdForEditAsync(int id)
        {
             var categories = await context.Categories
                .Select(c => new CategoryViewModel(){
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return await this.context
                .Books
                .Where(b => b.Id == id)
                .Select(b => new EditBookViewModel()
                {
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating.ToString(),
                    CategoryId = b.CategoryId,
                    Categories = categories
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<MineBookViewModel>> GetMine(string userId)
        {
            return await this.context.UsersBooks
                .Where(b => b.CollectorId == userId)
                .Select(b => new MineBookViewModel()
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name,
                })
                .ToListAsync();
        }

        public async Task<AddBookViewModel> GetNewAddBookModelAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel(){
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return model;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel book)
        {
            var userBook = await this.context
                .UsersBooks
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (book != null)
            {
                this.context.UsersBooks.Remove(userBook);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
