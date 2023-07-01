using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class changedPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("827f5ec5-c102-4b0f-9666-b9507e0a5fad"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("d561d896-86a5-4473-95d2-a98b9819589f"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("e8d07cbc-e2ff-4bf7-a521-d3693b91e507"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 15, 1, 41, 290, DateTimeKind.Utc).AddTicks(7780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 14, 14, 6, 441, DateTimeKind.Utc).AddTicks(1043));

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("06c02811-7361-4503-b67f-968a2df94b51"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 2, "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("14a91f91-701f-442a-badb-26367daad031"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 2, "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("1f763944-7e2e-431b-93e4-bd05484efe3a"), "North London, UK (near the border)", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 3, "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.thehousedesigners.com/images/plans/URD/bulk/6583/the-destination-interior-4.jpg", 2100.00m, new Guid("65c2c7fb-a186-4426-bdcd-08db7a30282f"), "Big House Marina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("06c02811-7361-4503-b67f-968a2df94b51"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("14a91f91-701f-442a-badb-26367daad031"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("1f763944-7e2e-431b-93e4-bd05484efe3a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 1, 14, 14, 6, 441, DateTimeKind.Utc).AddTicks(1043),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 1, 15, 1, 41, 290, DateTimeKind.Utc).AddTicks(7780));

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("827f5ec5-c102-4b0f-9666-b9507e0a5fad"), "Boyana Neighbourhood, Sofia, Bulgaria", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This luxurious house is everything you will need. It is just excellent.", "https://i.pinimg.com/originals/a6/f5/85/a6f5850a77633c56e4e4ac4f867e3c00.jpg", 2000.00m, null, "Grand House" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("d561d896-86a5-4473-95d2-a98b9819589f"), "Near the Sea Garden in Burgas, Bulgaria", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It has the best comfort you will ever ask for. With two bedrooms, it is great for your family.", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/179489660.jpg?k=2029f6d9589b49c95dcc9503a265e292c2cdfcb5277487a0050397c3f8dd545a&o=&hp=1", 1200.00m, null, "Family House Comfort" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CreatedOn", "Description", "ImageUrl", "PricePerMonth", "RenterId", "Title" },
                values: new object[] { new Guid("e8d07cbc-e2ff-4bf7-a521-d3693b91e507"), "North London, UK (near the border)", new Guid("8b9dcc2c-56dc-4bed-82d4-bfd844793d44"), 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A big house for your whole family. Don't miss to buy a house with three bedrooms.", "https://www.luxury-architecture.net/wpcontent/uploads/2017/12/1513217889-7597-FAIRWAYS-010.jpg", 2100.00m, new Guid("65c2c7fb-a186-4426-bdcd-08db7a30282f"), "Big House Marina" });
        }
    }
}
