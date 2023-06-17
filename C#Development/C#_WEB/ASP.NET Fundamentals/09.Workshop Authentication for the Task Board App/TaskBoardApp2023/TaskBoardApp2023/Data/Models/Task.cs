using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp2023.Data.DataConstants.Task;

namespace TaskBoardApp2023.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TaskMaxTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TaskMaxDescription)]
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        public IdentityUser Owner { get; set; } = null!;
    }
}
