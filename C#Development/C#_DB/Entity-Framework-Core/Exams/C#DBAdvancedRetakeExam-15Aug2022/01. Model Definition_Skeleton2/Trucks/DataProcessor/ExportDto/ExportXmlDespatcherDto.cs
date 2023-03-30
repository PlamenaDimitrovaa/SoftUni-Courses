
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportXmlDespatcherDto
    {
        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; } = null!;

        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlArray("Trucks")]
        public ExportXmlTruckDto[] Trucks { get; set; } = null!;
    }
}
