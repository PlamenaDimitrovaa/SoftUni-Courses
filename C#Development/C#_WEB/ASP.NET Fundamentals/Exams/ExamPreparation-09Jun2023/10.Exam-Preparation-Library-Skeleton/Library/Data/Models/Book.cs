using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Library.Common.EntityValidationConstants.Book;


namespace Library.Data.Models
{
    [Comment("Book of the library!")]
    public class Book
    {
        [Key]
        [Comment("Id - primary key")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Title of the book")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorMaxLength)]
        [Comment("Author of the book")]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the book")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("ImageUrl of the book")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        [Comment("Rating of the book")]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        [Comment("Category of the book")]
        public Category Category { get; set; } = null!;

        [Comment("Users Books Collection")]
        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();   
    }
}

//Has Id – a unique integer, Primary Key
//• Has Title – a string with min length 10 and max length 50 (required)
//• Has Author – a string with min length 5 and max length 50 (required)
//• Has Description – a string with min length 5 and max length 5000 (required)
//• Has ImageUrl – a string (required)
//• Has Rating – a decimal with min value 0.00 and max value 10.00 (required)
//• Has CategoryId – an integer, foreign key (required)
//• Has Category – a Category (required)
//• Has UsersBooks – a collection of type IdentityUserBook