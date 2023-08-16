using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Book;
using static Library.Common.EntityValidationConstants.Category;

namespace Library.Models.Book
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
