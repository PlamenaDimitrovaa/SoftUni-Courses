using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ExportDto
{
    public class ExportJsonSellerDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [RegularExpression("www\\.[A-z0-9-]*.com")]
        public string Website { get; set; } = null!;

        public ExportJsonBoardgameDto[] Boardgames { get; set; }
    }
}
