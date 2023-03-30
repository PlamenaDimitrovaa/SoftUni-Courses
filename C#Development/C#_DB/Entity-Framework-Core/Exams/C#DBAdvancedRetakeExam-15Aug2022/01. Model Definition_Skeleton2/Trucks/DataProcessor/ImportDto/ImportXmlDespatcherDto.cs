
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportXmlDespatcherDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [Required]
        [XmlElement("Position")]
        public string Position { get; set; } = null!;

        [XmlArray("Trucks")]
        public ImportXmlTruckDto[] Trucks { get; set; }
    }
}
