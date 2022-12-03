using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string CountryName { get; set; }

        [Range(50000, 10000000)]
        public int ArmySize { get; set; }
        public ICollection<CountryGun> CountriesGuns { get; set; }
    }
}
