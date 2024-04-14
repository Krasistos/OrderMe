using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class UrlAddedToMenuItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "MenuItems",
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
                values: new object[] { "f6432d66-5149-4689-ba5c-505a1c1409d6", "AQAAAAEAACcQAAAAEH38XnBS1wT4m+UpAmzUJq7x5AL2BIFvEQH2MpkGXSD0P4SQsU0rF6EH4vB/JixXJA==", "9406deed-215c-4d65-8e4c-ab43f5291482" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "699c2389-c9a1-4783-a212-a7c7fff03048", "AQAAAAEAACcQAAAAEGo3SxV7x4koQesiKCWtmG9/tfVIW1TCeKNKCX/yKFdkXzaHDmIN4/MUbEMiEMHxNQ==", "ee135151-1c30-484e-a603-1d7c381d6693" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "MenuItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb1d930c-24ba-45c3-ae5d-4c3c97930e63", "AQAAAAEAACcQAAAAELx7fn+3DocOjfmzzSHsOuNJSovMa7FxDsYG+PwgqCZVP4qJnozlK3eRPHWjjBhXKg==", "ea39f1fb-785b-44cb-8c7a-af02ee150449" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "391899b4-123c-468c-8b29-42ad301204cb", "AQAAAAEAACcQAAAAEEittte686rtQ2LbaaNX3mu/dpr7FKXCnOa4ZJPKrWUOAs6M/PPVwPeo7B82qzqQxg==", "bf253231-c6d7-4fba-b4c3-e82952816c8f" });
        }
    }
}
