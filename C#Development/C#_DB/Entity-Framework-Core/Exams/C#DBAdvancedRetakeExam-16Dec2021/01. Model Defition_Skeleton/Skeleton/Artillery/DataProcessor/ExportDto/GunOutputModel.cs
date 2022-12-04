using Artillery.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;
using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Gun")]
    public class GunOutputModel
    {
        [XmlAttribute("Manufacturer")]
        [Required]
        [StringLength(40, MinimumLength = 4)]
        public string Manufactrurer { get; set; }

        [XmlAttribute("GunType")]
        [Required]
        [EnumDataType(typeof(GunType))]
        public string GunType { get; set; }

        [Range(100, 1350000)]
        [XmlAttribute("GunWeight")]
        public int GunWeight { get; set; }

        [Range(2.00, 35.00)]
        [XmlAttribute("BarrelLength")]
        public double BarrelLength { get; set; }

        [XmlAttribute("Range")]
        [Range(1, 100000)]
        public int Range { get; set; }

        [XmlArray("Countries")]
        public CountryOutputModel[] Countries { get; set; }
    }
}
