
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportJsonSellerDto
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        [JsonProperty("Address")]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression("www\\.[A-z0-9-]*.com")]
        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[] Boardgames { get; set; }
    }
}
