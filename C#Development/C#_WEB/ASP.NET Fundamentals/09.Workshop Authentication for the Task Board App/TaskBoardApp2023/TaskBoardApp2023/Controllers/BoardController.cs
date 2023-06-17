using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp2023.Data;
using TaskBoardApp2023.Models.Board;
using TaskBoardApp2023.Models.Task;

namespace TaskBoardApp2023.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public BoardController(TaskBoardAppDbContext context)
        {
            this.data = context;
        }
        public async Task<IActionResult> All()
        {
            var boards = await data
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b
                            .Tasks
                            .Select(t => new TaskViewModel()
                            {
                                Id = t.Id,
                                Title = t.Title,
                                Description = t.Description,
                                Owner = t.Owner.UserName
                            })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
