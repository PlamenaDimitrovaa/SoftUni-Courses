﻿
using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new HashSet<Footballer>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]  
        public string Nationality { get; set; } = null!;
        public virtual ICollection<Footballer> Footballers { get; set; }
    }
}