using Artillery.Common;
using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Range(ValidationConstants.ShellWeightFrom, ValidationConstants.ShellWeightTo)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CaliberMaxLength)]
        [MinLength(ValidationConstants.CaliberMinLength)]
        public string Caliber { get; set; } = null!;

        public virtual ICollection<Gun> Guns { get; set; }
    }
}
