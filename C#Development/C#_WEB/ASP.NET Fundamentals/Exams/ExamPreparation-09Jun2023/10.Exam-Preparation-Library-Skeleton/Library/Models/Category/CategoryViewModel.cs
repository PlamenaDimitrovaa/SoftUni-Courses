using System.ComponentModel.DataAnnotations;

using static Library.Common.EntityValidationConstants.Category;

namespace Library.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
