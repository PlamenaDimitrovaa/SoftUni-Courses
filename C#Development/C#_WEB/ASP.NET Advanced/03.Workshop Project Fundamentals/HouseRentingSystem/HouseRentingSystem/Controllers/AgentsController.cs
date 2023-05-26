using HouseRentingSystem.Models.Agents;
using HouseRentingSystem.Services.Agents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class AgentsController : Controller
    {
        private readonly IAgentService agents;

        public AgentsController(IAgentService agents)
        {
            this.agents = agents;
        }

        [Authorize]
        public IActionResult Become()
        {
            return View();
        }

        [Authorize]
        public IActionResult Become()
        {
            if (this.agents.ExistsById(this.User.Id()))
            {
                return BadRequest();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel agent)
        {
            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
