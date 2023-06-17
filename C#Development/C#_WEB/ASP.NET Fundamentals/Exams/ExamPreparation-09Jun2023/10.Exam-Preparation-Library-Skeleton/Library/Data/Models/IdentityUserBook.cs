using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("Identity User Book")]
    public class IdentityUserBook
    {
        [Required]
        [Comment("Collector Id")]
        public string CollectorId { get; set; } = null!;

        [ForeignKey(nameof(CollectorId))]
        [Comment("Collector")]
        public IdentityUser Collector { get; set; } = null!;

        [Required]
        [Comment("Book Id")]
        public int BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        [Comment("Book")]
        public Book Book { get; set; } = null!;
    }
}
