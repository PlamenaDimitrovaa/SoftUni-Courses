using Homies.Models.Event;

namespace Homies.Constraints
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();

        Task<IEnumerable<EventViewModel>> GetJoinedEventsAsync(string userId);

        Task<AddEventViewModel> GetNewAddEventAsync();

        Task AddEventAsync(AddEventViewModel model);

        Task<EventViewModel?> GetEventByIdAsync(int id);

        Task AddEventToCollectionAsync(string userId, EventViewModel model);

        Task<EditEventViewModel?> GetByIdForEditAsync(int id);

        Task EditEventAsync(EditEventViewModel model, int id);

        Task RemoveFromCollectionAsync(EventViewModel model, string userId);

        Task<DetailsViewModel> GetDetails(int id);

    }
}
