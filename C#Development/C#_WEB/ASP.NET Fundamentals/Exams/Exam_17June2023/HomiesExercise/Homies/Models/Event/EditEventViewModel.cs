using Homies.Models.Type;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Event;

namespace Homies.Models.Event
{
    public class EditEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public string Start { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd H:mm}", ApplyFormatInEditMode = true)]
        public string End { get; set; } = null!;

        public string OrganiserId { get; set; }

        [Required]
        public int TypeId { get; set; }

        public ICollection<TypeViewModel> Types { get; set; }
         = new List<TypeViewModel>();
    }
}
