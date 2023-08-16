using Library.Models.Book;

namespace Library.Services.Interfaces
{
    public interface IBookService
    {
        Task AddBookAsync(AddBookViewModel model);
        Task AddBookToCollectionAsync(string userId, BookViewModel book);
        Task EditBookAsync(int id, EditBookViewModel model);
        Task<ICollection<AllBookViewModel>> GetAll();
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task<EditBookViewModel?> GetBookByIdForEditAsync(int id);
        Task<ICollection<MineBookViewModel>> GetMine(string userId);
        Task<AddBookViewModel> GetNewAddBookModelAsync();
        Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);
    }
}
