using Library.Infrastructure;
using Library.Models.Book;
using Library.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        public async Task<IActionResult> All()
        {
            var model = await this.bookService.GetAll();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = this.User.Id();
            var model = await this.bookService.GetMine(userId);
            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserId();

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("Mine");
            }

            var userId = GetUserId();

            await bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction("Mine");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetNewAddBookModelAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditBookViewModel book = await bookService.GetBookByIdForEditAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBookViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.EditBookAsync(id, model);

            return RedirectToAction("All");
        }
    }
}
