using Footballers.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    public class TeamJsonInputModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [RegularExpression(@"^[\w.\d\s-]+$")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }
        public int Trophies { get; set; }
        public List<int> Footballers { get; set; }
    }
}
