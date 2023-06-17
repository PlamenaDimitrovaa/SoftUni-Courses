using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskBoardApp2023.Models;

namespace TaskBoardApp2023.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}