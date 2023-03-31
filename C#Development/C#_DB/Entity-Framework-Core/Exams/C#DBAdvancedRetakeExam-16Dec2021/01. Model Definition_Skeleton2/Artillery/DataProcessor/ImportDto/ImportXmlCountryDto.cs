
using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Country")]
    public class ImportXmlCountryDto
    {
        [XmlElement("CountryName")]
        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        [MinLength(ValidationConstants.CountryNameMinLength)]
        public string CountryName { get; set; } = null!;

        [XmlElement("ArmySize")]
        [Range(ValidationConstants.ArmySizeFrom, ValidationConstants.ArmySizeTo)]
        public int ArmySize { get; set; }
    }
}
