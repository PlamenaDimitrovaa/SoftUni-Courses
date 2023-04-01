using Boardgames.Data.Models.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace Boardgames.DataProcessor.ExportDto
{
    public class ExportJsonBoardgameDto
    {
        [JsonProperty("Name")]
        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [JsonProperty("Rating")]
        [Range(1, 10.00)]
        public double Rating { get; set; }

        [JsonProperty("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;

        [JsonProperty("Category")]
        [EnumDataType(typeof(CategoryType))]
        [Required]
        public string Category { get; set; } = null!;
    }
}
