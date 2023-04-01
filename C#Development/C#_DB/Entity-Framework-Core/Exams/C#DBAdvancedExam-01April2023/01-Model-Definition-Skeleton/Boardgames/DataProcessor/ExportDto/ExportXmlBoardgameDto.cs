
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Boardgame")]
    public class ExportXmlBoardgameDto
    {
        [XmlElement("BoardgameName")]
        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string BoardgameName { get; set; } = null!;

        [XmlElement("BoardgameYearPublished")]
        [Range(2018, 2023)]
        public int BoardgameYearPublished { get; set; }
    }
}
