using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp2023.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a841dd85-f829-4bd5-85c2-b2e5133da151", 0, "92ca3780-7d86-43ac-a57d-77a113aaff2d", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEAu5afapJZv1xUsCYgKJHOdqowa3S1RjQHNbXLYmt/Ovxl7f3SXBYKXt6WT4C8Syaw==", null, false, "e04d4916-679f-459d-8c74-b5e7e550842c", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 5, 17, 13, 1, 36, 213, DateTimeKind.Local).AddTicks(5598), "Learn using ASP .NET Core Identity", "a841dd85-f829-4bd5-85c2-b2e5133da151", "Prepare for ASP.NET Fundamentals exam" },
                    { 2, 3, new DateTime(2023, 1, 17, 13, 1, 36, 213, DateTimeKind.Local).AddTicks(5631), "Learn using EF Core and MS SQL Server Management Studio", "a841dd85-f829-4bd5-85c2-b2e5133da151", "Improve EF Core skills" },
                    { 3, 2, new DateTime(2023, 6, 7, 13, 1, 36, 213, DateTimeKind.Local).AddTicks(5634), "Learn using ASP.NET Core Identity", "a841dd85-f829-4bd5-85c2-b2e5133da151", "Improve ASP.NET Core skills" },
                    { 4, 3, new DateTime(2022, 6, 17, 13, 1, 36, 213, DateTimeKind.Local).AddTicks(5636), "Prepare by solving old Mid and Final exams", "a841dd85-f829-4bd5-85c2-b2e5133da151", "Prepare for C# Fundamentals Exam" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a841dd85-f829-4bd5-85c2-b2e5133da151");
        }
    }
}
