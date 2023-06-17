using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    public partial class TableRenamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_AspNetUsers_CollectorId",
                table: "UsersBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks");

            migrationBuilder.RenameTable(
                name: "UsersBooks",
                newName: "IdentityUserBooks");

            migrationBuilder.RenameIndex(
                name: "IX_UsersBooks_BookId",
                table: "IdentityUserBooks",
                newName: "IX_IdentityUserBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserBooks",
                table: "IdentityUserBooks",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserBooks_Books_BookId",
                table: "IdentityUserBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_AspNetUsers_CollectorId",
                table: "IdentityUserBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserBooks_Books_BookId",
                table: "IdentityUserBooks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserBooks",
                table: "IdentityUserBooks");

            migrationBuilder.RenameTable(
                name: "IdentityUserBooks",
                newName: "UsersBooks");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserBooks_BookId",
                table: "UsersBooks",
                newName: "IX_UsersBooks_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersBooks",
                table: "UsersBooks",
                columns: new[] { "CollectorId", "BookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_AspNetUsers_CollectorId",
                table: "UsersBooks",
                column: "CollectorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBooks_Books_BookId",
                table: "UsersBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
