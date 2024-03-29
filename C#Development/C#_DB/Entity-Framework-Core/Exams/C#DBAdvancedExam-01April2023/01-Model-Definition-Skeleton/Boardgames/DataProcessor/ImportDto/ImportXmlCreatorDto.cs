﻿
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportXmlCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportXmlBoardgameDto[] Boardgames { get; set; }
    }
}
