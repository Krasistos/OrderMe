using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class SeededAllEntitiesAndAddedImageUrlColumnInVehicleEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Vehicles",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                comment: "Image URL of the menu item");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e45a876-3272-4611-afc9-dc28a2feab49", "AQAAAAEAACcQAAAAEIngkVr9l1lwYzWTatcELxmTMM++ldYIyHHUFKO4F7Ee52rE1ml0bOBsa7S8yn52Qg==", "04c7ddc5-0f53-4036-a5ee-bddb70780b12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d74a1749-a108-4921-a9b5-0dbbc08adc9d", "AQAAAAEAACcQAAAAEGo1UvLePtE+A8MJBd37hXhe4XUU4IgM4asNGGM050uucKn0d3Q0ZIbmEsUVJpbkiA==", "22550293-60a9-4450-890a-3765477a2bf0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6432d66-5149-4689-ba5c-505a1c1409d6", "AQAAAAEAACcQAAAAEH38XnBS1wT4m+UpAmzUJq7x5AL2BIFvEQH2MpkGXSD0P4SQsU0rF6EH4vB/JixXJA==", "9406deed-215c-4d65-8e4c-ab43f5291482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "699c2389-c9a1-4783-a212-a7c7fff03048", "AQAAAAEAACcQAAAAEGo3SxV7x4koQesiKCWtmG9/tfVIW1TCeKNKCX/yKFdkXzaHDmIN4/MUbEMiEMHxNQ==", "ee135151-1c30-484e-a603-1d7c381d6693" });
        }
    }
}
