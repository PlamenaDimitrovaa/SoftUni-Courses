using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class TruckExportModel
    {
        [XmlElement("RegistrationNumber")]
        [StringLength(8)]
        public string RegistrationNumber { get; set; }

        [XmlElement("Make")]
        [Required]
        [EnumDataType(typeof(MakeType))]
        public string Make { get; set; }
    }
}