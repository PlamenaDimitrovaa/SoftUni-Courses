using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Constants.DataConstants.Post;

namespace ForumApp.Data
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Posts Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Post title")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(ContentMaxLength)]
        [Comment("Content")]
        public string Content { get; set; } = null!;

        [Comment("Marks record as deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }   
}
