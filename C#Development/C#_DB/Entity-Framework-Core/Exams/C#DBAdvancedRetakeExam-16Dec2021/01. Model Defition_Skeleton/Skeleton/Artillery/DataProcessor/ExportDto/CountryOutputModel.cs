using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class CountryOutputModel
    {
        [XmlAttribute("Country")]
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string Country { get; set; }

        [XmlAttribute("ArmySize")]
        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
    }
}