using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Event;

namespace Homies.Models.Event
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public string Organiser { get; set; } = null!;
    }
}
