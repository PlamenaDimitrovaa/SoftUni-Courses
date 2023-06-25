using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Event;

namespace Homies.Models.Event
{
    public class AddEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public string Start { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public string End { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; }
         = new List<TypeViewModel>();
    }
}
