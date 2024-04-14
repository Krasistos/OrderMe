using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class GuestFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66785426-86f9-43ad-b6e0-35d32b46cb54", "AQAAAAEAACcQAAAAEOldNAc6yp5fA8+CvoBva6/4PuCCpDIBMCUKMPrXjCMgAg7n7lZJQB90/bIuWUXzQg==", "7c76a19f-8b86-4414-a99c-5adcc89f3e49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33b4825e-d18c-408b-9ffb-09bc0fb85931", "AQAAAAEAACcQAAAAEO4Lwu2Wsb17WQYbUb8CiLtcPF+y4L2OdTLgSIrpo/X3xZPHtxgRRu5QbyrYD93BPg==", "c8f2bcbb-5423-412e-be3f-c8b46b5a748b" });
        }
    }
}
