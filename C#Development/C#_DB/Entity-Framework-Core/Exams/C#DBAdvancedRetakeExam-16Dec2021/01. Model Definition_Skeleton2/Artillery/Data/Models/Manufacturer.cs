using Artillery.Common;
using System.ComponentModel.DataAnnotations;


namespace Artillery.Data.Models
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ManufacturerNameMaxLength)]
        [MinLength(ValidationConstants.ManufacturerNameMinLength)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.FoundedMaxLength)]
        [MinLength(ValidationConstants.FoundedMinLength)]
        public string Founded { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; } = null!;
    }
}
