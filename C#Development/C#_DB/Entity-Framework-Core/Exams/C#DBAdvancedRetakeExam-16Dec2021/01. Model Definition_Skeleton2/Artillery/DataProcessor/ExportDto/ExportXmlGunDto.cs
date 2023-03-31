using Artillery.Common;
using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class ExportXmlGunDto
    {
        [XmlAttribute("Manufacturer")]
        [Required]
        [StringLength(ValidationConstants.ManufacturerNameMaxLength, MinimumLength = ValidationConstants.ManufacturerNameMinLength)]
        public string Manufacturer { get; set; } = null!;

        [XmlAttribute("GunType")]
        [Required]
        [EnumDataType(typeof(GunType))]
        public string GunType { get; set; } = null!;

        [XmlAttribute("GunWeight")]
        [Range(ValidationConstants.GunWeightFrom, ValidationConstants.GunWeightTo)]
        public int GunWeight { get; set; }

        [XmlAttribute("BarrelLength")]
        [Range(ValidationConstants.BarrelLengthFrom, ValidationConstants.BarrelLengthTo)]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        [Range(ValidationConstants.RangeFrom, ValidationConstants.RangeTo)]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public ExportXmlCountryDto[] Countries { get; set; }
    }
}
