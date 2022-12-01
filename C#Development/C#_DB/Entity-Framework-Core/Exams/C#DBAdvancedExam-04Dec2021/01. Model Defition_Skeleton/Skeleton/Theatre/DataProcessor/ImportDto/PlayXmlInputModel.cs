using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using Theatre.Data.Models;
using System.ComponentModel.DataAnnotations;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayXmlInputModel
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Range(typeof(float), "0.00", "10.00")]
        [XmlElement("Rating")]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        [EnumDataType(typeof(Genre))]
        public string Genre { get; set; }

        [Required]
        [MaxLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}
