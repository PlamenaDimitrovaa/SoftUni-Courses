using Homies.Constraints;
using Homies.Models.Event;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> All()
        {
            var model = await service.GetAllEventsAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var model = await service.GetJoinedEventsAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var eventt = await service.GetEventByIdAsync(id);
            var events = await service.GetJoinedEventsAsync(GetUserId());

            if (events.Any(e => e.Id == eventt.Id))
            {
                return RedirectToAction("All", "Event");
            }

            if (eventt == null)
            {
                return RedirectToAction("All", "Event");
            }

            await service.AddEventToCollectionAsync(GetUserId(), eventt);
            return RedirectToAction("Joined", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await service.GetNewAddEventAsync();
            model.OrganiserId = GetUserId();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(model.Start, out start))
            {
                ModelState.AddModelError(nameof(model.Start), "Start date cannot be parse");
                return View(model);
            }

            if (!DateTime.TryParse(model.End, out end))
            {
                ModelState.AddModelError(nameof(model.End), "End date cannot be parse");
                return View(model);
            }

            if (start > end)
            {
                ModelState.AddModelError(nameof(model.Start), "Start date cannot be after end date");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            await service.AddEventAsync(model);
            return RedirectToAction("All", "Event");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditEventViewModel eventt = await service.GetByIdForEditAsync(id);

            eventt.OrganiserId = GetUserId();

            if (eventt == null)
            {
                return RedirectToAction("All", "Event");
            }

            if (eventt.OrganiserId != GetUserId())
            {
                return RedirectToAction(nameof(All));
            }

            return View(eventt);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEventViewModel model, int id)
        {
            DateTime start;
            DateTime end;

            if (!DateTime.TryParse(model.Start, out start))
            {
                ModelState.AddModelError(nameof(model.Start), "Start date cannot be parse");
                return View(model);
            }

            if (!DateTime.TryParse(model.End, out end))
            {
                ModelState.AddModelError(nameof(model.End), "End date cannot be parse");
                return View(model);
            }

            if (start > end)
            {
                ModelState.AddModelError(nameof(model.Start), "Start date cannot be after end date");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.EditEventAsync(model, id);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            EventViewModel eventt = await service.GetEventByIdAsync(id);

            if (eventt == null)
            {
                return RedirectToAction("All", "Event");
            }

            await service.RemoveFromCollectionAsync(eventt, GetUserId());
           
            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventt = await service.GetDetails(id);

            if (eventt == null)
            {
                return BadRequest();
            }

            return View(eventt);
        }
    }
}
