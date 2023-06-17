﻿using System.ComponentModel.DataAnnotations;

using static TaskBoardApp2023.Data.DataConstants.Board;

namespace TaskBoardApp2023.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardMaxName)]
        public string Name { get; set; } = null!;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
