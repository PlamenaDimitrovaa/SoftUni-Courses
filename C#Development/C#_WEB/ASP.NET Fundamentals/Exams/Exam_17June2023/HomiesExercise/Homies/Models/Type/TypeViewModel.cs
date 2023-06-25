using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Typee;

namespace Homies.Models.Type
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
