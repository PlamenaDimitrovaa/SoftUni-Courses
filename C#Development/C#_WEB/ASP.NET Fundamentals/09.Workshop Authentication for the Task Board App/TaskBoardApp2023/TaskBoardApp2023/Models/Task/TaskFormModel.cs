﻿using System.ComponentModel.DataAnnotations;

using static TaskBoardApp2023.Data.DataConstants.Board;
using static TaskBoardApp2023.Data.DataConstants.Task;


namespace TaskBoardApp2023.Models.Task
{
    public class TaskFormModel
    {
        [Required]
        [StringLength(TaskMaxTitle, MinimumLength = TaskMinTitle,
            ErrorMessage = "Title should be at least {2} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(TaskMaxDescription, MinimumLength = TaskMinDescription,
            ErrorMessage = "Description should be at least {2} characters long.")]
        public string Description { get; set; } = null!;

        [Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
