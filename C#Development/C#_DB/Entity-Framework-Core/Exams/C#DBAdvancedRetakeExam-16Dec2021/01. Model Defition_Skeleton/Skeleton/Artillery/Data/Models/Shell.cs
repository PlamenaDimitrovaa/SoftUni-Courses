using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public int Id { get; set; }

        [Range(2, 1680)]
        public double ShellWeight { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Caliber { get; set; }
        public ICollection<Gun> Guns { get; set; }
    }
}
