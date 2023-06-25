using Homies.Constraints;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models.Event;
using Homies.Models.Type;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;
        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task AddEventAsync(AddEventViewModel model)
        {
            Event eventt = new Event()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Start = DateTime.Parse(model.Start),
                End = DateTime.Parse(model.End),
                TypeId = model.TypeId,
                OrganiserId = model.OrganiserId,
            };

            await context.Events.AddAsync(eventt);
            await context.SaveChangesAsync();
        }

        public async Task AddEventToCollectionAsync(string userId, EventViewModel model)
        {
            bool alreadyAdded = await context.EventsParticipants
                .AnyAsync(ep => ep.HelperId == userId && ep.EventId == model.Id);

            if (!alreadyAdded)
            {
                var eventt = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = model.Id,
                };

                await context.EventsParticipants.AddAsync(eventt);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditEventAsync(EditEventViewModel model, int id)
        {
            var eventt = await context.Events.FindAsync(id);

            if (eventt != null)
            {
                eventt.Id = model.Id;
                eventt.Name = model.Name;
                eventt.Description = model.Description;
                eventt.Start = DateTime.Parse(model.Start);
                eventt.End = DateTime.Parse(model.End);
                eventt.TypeId = model.TypeId;

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
        {
            return await context.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                }).ToListAsync();
        }

        public async Task<EditEventViewModel> GetByIdForEditAsync(int id)
        {
            var types = await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            return await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EditEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(),
                    End = e.End.ToString(),
                    TypeId = e.TypeId,
                    Types = types
                }).FirstOrDefaultAsync();
        }

        public async Task<DetailsViewModel> GetDetails(int id)
        {
            return await this.context.Events
                .Where(e => e.Id == id)
                .Select(t => new DetailsViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Start = t.Start.ToString("yyyy-MM-dd H:mm"),
                    End = t.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = t.Organiser.UserName,
                    CreatedOn = t.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Type = t.Type.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<EventViewModel?> GetEventByIdAsync(int id)
        {
            return await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("dd/MM/yyyy H:mm"),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName,
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await context.EventsParticipants
                .Where(e => e.HelperId == userId)
                .Select(e => new EventViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start.ToString("dd/MM/yyyy H:mm"),
                    Type = e.Event.Type.Name,
                    Organiser = e.Event.Organiser.UserName,
                }).ToListAsync();
        }

        public async Task<AddEventViewModel> GetNewAddEventAsync()
        {
            var types = await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();

            var model = new AddEventViewModel()
            {
                Types = types,
            };

            return model;
        }

        public async Task RemoveFromCollectionAsync(EventViewModel model, string userId)
        {
            var eventParticipant = await context.EventsParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == userId && ep.EventId == model.Id);

            if (eventParticipant != null)
            {
                context.EventsParticipants.Remove(eventParticipant);
                await context.SaveChangesAsync();
            }
        }
    }
}
