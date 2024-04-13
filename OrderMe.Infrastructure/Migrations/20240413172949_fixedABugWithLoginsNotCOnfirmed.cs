using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class fixedABugWithLoginsNotCOnfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66785426-86f9-43ad-b6e0-35d32b46cb54", true, "AQAAAAEAACcQAAAAEOldNAc6yp5fA8+CvoBva6/4PuCCpDIBMCUKMPrXjCMgAg7n7lZJQB90/bIuWUXzQg==", "7c76a19f-8b86-4414-a99c-5adcc89f3e49" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33b4825e-d18c-408b-9ffb-09bc0fb85931", true, "AQAAAAEAACcQAAAAEO4Lwu2Wsb17WQYbUb8CiLtcPF+y4L2OdTLgSIrpo/X3xZPHtxgRRu5QbyrYD93BPg==", "c8f2bcbb-5423-412e-be3f-c8b46b5a748b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1f27c48-23e6-463a-86b3-6b127e592149", false, "AQAAAAEAACcQAAAAEMDGt6y8uWRPYEClPw5vvKIv1zVY0LE6hxl9IQhTnMBC0/JQARhoznOqxxErlzkeLw==", "bf5e6673-a425-454d-8445-9bbe6821a128" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c039b874-2ca3-4011-87e1-0a1e0238a84e", false, "AQAAAAEAACcQAAAAEIvWpjlv+iQy4fsWhiCvbHDkkmWbRSIZyhWoO1BS1Yyd34WkbKFIbHu6revIPQKtWg==", "f02a1a0d-1cc3-481b-9f2d-735dceca75ca" });
        }
    }
}
