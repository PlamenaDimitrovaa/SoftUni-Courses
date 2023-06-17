using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp2023.Data.Models;

namespace TaskBoardApp2023.Data
{
    public class TaskBoardAppDbContext : IdentityDbContext<IdentityUser>
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Models.Task> Tasks { get; set; }

        public IdentityUser TestUser { get; set; }

        public Board OpenBoard { get; set; }

        public Board InProgressBoard { get; set; }

        public Board DoneBoard { get; set; }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG",
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        private void SeedBoards()
        {
            this.OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };
            this.InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };
            this.DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Models.Task>()
                .HasOne(t => t.Board)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedUsers();
            builder.Entity<IdentityUser>().HasData(TestUser);

            SeedBoards();
            builder.Entity<Board>().HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder.Entity<Models.Task>()
                .HasData(new Models.Task()
                {
                    Id = 1,
                    Title = "Prepare for ASP.NET Fundamentals exam",
                    Description = "Learn using ASP .NET Core Identity",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.OpenBoard.Id
                },
                new Models.Task()
                {
                    Id = 2,
                    Title = "Improve EF Core skills",
                    Description = "Learn using EF Core and MS SQL Server Management Studio",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.DoneBoard.Id
                },
                new Models.Task()
                {
                    Id = 3,
                    Title = "Improve ASP.NET Core skills",
                    Description = "Learn using ASP.NET Core Identity",
                    CreatedOn = DateTime.Now.AddDays(-10),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.InProgressBoard.Id
                },
                new Models.Task()
                {
                    Id = 4,
                    Title = "Prepare for C# Fundamentals Exam",
                    Description = "Prepare by solving old Mid and Final exams",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = this.TestUser.Id,
                    BoardId = this.DoneBoard.Id
                }
                );

            base.OnModelCreating(builder);
        }
    }
}