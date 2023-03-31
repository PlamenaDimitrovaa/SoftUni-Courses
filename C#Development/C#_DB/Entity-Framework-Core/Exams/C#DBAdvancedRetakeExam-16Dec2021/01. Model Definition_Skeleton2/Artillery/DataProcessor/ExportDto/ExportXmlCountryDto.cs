using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class ExportXmlCountryDto
    {
        [XmlAttribute("Country")]
        [Required]
        [StringLength(ValidationConstants.CountryNameMaxLength, MinimumLength = ValidationConstants.CountryNameMinLength)]
        public string Country { get; set; } = null!;

        [XmlAttribute("ArmySize")]
        [Range(ValidationConstants.ArmySizeFrom, ValidationConstants.ArmySizeTo)]
        public int ArmySize { get; set; }
    }
}
