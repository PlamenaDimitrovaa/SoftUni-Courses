using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckModel
    {
        [XmlElement("RegistrationNumber")]
        [StringLength(8)]
        [RegularExpression("[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string RegistrationNumber { get; set; }

        [XmlElement("VinNumber")]
        [Required]
        [StringLength(17)]
        [RegularExpression("[A-Z0-9]{17}")]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950, 1420)]
        public int TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000, 29000)]
        public int CargoCapacity { get; set; }

        [Required]
        [XmlElement("CategoryType")]
        [EnumDataType(typeof(CategoryType))]
        public int CategoryType { get; set; }

        [Required]
        [XmlElement("MakeType")]
        [EnumDataType(typeof(MakeType))]
        public int MakeType { get; set; }
    }
}