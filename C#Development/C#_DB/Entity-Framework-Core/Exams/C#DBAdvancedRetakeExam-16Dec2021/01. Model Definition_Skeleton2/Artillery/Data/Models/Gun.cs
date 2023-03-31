using Artillery.Common;
using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class Gun
    {
        public Gun()
        {
            this.CountriesGuns = new HashSet<CountryGun>();
        }

        [Key]
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [Range(ValidationConstants.GunWeightFrom, ValidationConstants.GunWeightTo)]
        public int GunWeight { get; set; }

        [Range(ValidationConstants.BarrelLengthFrom, ValidationConstants.BarrelLengthTo)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; } //???

        [Range(ValidationConstants.RangeFrom, ValidationConstants.RangeTo)]
        public int Range { get; set; }

        public GunType GunType { get; set; }

        public int ShellId { get; set; }

        [ForeignKey(nameof(ShellId))]
        public Shell Shell { get; set; } = null!;

        public virtual ICollection<CountryGun> CountriesGuns { get; set; } = null!;
    }
}
