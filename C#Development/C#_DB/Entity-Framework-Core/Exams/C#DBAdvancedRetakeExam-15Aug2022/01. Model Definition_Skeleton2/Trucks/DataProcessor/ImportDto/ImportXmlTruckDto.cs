
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;
using Trucks.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportXmlTruckDto
    {
        [XmlElement("RegistrationNumber")]
        [MinLength(8)]
        [MaxLength(8)]
        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string? RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [MinLength(17)]
        [MaxLength(17)]
        //[RegularExpression("[A-Z0-9]{17}")]
        public string VinNumber { get; set; } = null!;

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [Range(0, 3)]
        //[EnumDataType(typeof(CategoryType))]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [Range(0, 4)]
        //[EnumDataType(typeof(MakeType))]
        public int MakeType { get; set; }
    }
}