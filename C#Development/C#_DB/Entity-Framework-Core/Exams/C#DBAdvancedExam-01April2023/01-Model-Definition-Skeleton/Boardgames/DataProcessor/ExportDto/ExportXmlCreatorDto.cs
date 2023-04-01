using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportXmlCreatorDto
    {
        [XmlAttribute("BoardgamesCount")]
        public int BoardgamesCount { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)] //??
        public string CreatorName { get; set; } = null!;

        public ExportXmlBoardgameDto[] Boardgames { get; set; }
    }
}
