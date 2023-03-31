using Artillery.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType("Manufacturer")]
    public class ImportXmlManufacturerDto
    {
        [XmlElement("ManufacturerName")]
        [Required]
        [StringLength(ValidationConstants.ManufacturerNameMaxLength, MinimumLength = ValidationConstants.ManufacturerNameMinLength)]
        public string ManufacturerName { get; set; } = null!;

        [Required]
        [XmlElement("Founded")]
        [StringLength(ValidationConstants.FoundedMaxLength, MinimumLength = ValidationConstants.FoundedMinLength)]
        public string Founded { get; set; } = null!;
    }
}
