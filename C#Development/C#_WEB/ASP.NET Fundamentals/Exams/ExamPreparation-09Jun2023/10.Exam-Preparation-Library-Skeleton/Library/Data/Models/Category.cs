using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Library.Common.EntityValidationConstants.Category;

namespace Library.Data.Models
{
    [Comment("Category of the book")]
    public class Category
    {
        [Key]
        [Comment("Id - primary key")]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
