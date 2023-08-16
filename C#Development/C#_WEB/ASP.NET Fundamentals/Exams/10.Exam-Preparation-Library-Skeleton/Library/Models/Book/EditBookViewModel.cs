using Library.Models.Category;
using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationConstants.Book;

namespace Library.Models.Book
{
    public class EditBookViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Url { get; set; } = null!;

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
        public string Rating { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
    }
}
