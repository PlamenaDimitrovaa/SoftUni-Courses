
using Artillery.Common;
using Artillery.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Artillery.DataProcessor.ImportDto
{
    public class ImportJsonGunDto
    {
        public int ManufacturerId { get; set; }

        [Range(ValidationConstants.GunWeightFrom, ValidationConstants.GunWeightTo)]
        public int GunWeight { get; set; }

        [Range(ValidationConstants.BarrelLengthFrom, ValidationConstants.BarrelLengthTo)]
        public double BarrelLength { get; set; }

        public int? NumberBuild { get; set; }

        [Range(ValidationConstants.RangeFrom, ValidationConstants.RangeTo)]
        public int Range { get; set; }

        [Required]
        [EnumDataType(typeof(GunType))]
        public string GunType { get; set; } = null!;

        public int ShellId { get; set; }

        public virtual ICollection<ImportJsonCountryDto> Countries { get; set; } = null!;
    }
}
