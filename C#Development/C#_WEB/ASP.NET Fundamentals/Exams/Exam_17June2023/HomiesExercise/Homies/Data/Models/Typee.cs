using System.ComponentModel.DataAnnotations;
using static Homies.Common.DataConstants.Typee;

namespace Homies.Data.Models
{
    public class Typee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
