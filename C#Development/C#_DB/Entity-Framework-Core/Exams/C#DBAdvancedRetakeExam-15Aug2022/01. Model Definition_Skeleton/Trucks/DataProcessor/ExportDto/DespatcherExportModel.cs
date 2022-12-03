using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class DespatcherExportModel
    {
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlElement("DespatcherName")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string DespatcherName { get; set; }

        [XmlArray("Trucks")]
        public TruckExportModel[] Trucks { get; set; }
    }
}
