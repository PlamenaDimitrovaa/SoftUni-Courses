
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportXmlTruckDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("Make")]
        public string Make { get; set; } = null!;
    }
}
