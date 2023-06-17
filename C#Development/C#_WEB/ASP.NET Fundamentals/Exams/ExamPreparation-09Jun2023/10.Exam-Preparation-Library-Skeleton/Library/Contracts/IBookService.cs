using Library.Models.Book;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<IEnumerable<MineBookViewModel>> GetMyBooksAsync(string userId);
        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);

        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task AddBookAsync(AddBookViewModel model);
        Task<EditBookViewModel?> GetBookByIdForEditAsync(int id);
        Task EditBookAsync(EditBookViewModel model, int id);
    }
}
