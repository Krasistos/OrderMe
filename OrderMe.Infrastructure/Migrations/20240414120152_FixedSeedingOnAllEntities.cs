using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class FixedSeedingOnAllEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902faf24-f408-411d-aadb-9a13261a9092", "AQAAAAEAACcQAAAAEAfHzUQ1KknPZzN6q2+KyAXJYwSGsYurZq5sZFqWPV4H9DSvt/91Atn09ZzYR1NCiA==", "b91d8193-1d46-4374-8d72-877797fc87eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd6a52e0-1607-4b2c-ac71-d2a2ea70cd1a", "AQAAAAEAACcQAAAAEDb2Z/HNjneBNFEgN1Xx12edORD8lHI3nVYnvxfYL5QuJk99LvpkGwMfsZUMV4VM1w==", "93da7797-1668-4d24-8588-b979677dfdc2" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "CreatedAt", "IsActive", "UserId" },
                values: new object[] { 1, new DateTime(2024, 4, 14, 12, 1, 51, 948, DateTimeKind.Utc).AddTicks(4437), true, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Garages",
                columns: new[] { "Id", "CreationDate", "IsActive", "LocationJson", "Name", "OrderMeAgencyId", "UserId" },
                values: new object[] { 1, new DateTime(2024, 4, 14, 12, 1, 51, 952, DateTimeKind.Utc).AddTicks(5926), true, "[42.713754697211016,23.302001953125]", "FastGarage", null, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "CartId", "Description", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[] { 1, null, "Tasty, with butter on top and some cream", "https://www.allrecipes.com/thmb/WqWggh6NwG-r8PoeA3OfW908FUY=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/21014-Good-old-Fashioned-Pancakes-mfs_001-1fa26bcdedc345f182537d95b6cf92d8.jpg", "Pancakes", 10.99m, 1 });

            migrationBuilder.InsertData(
                table: "OrderMeAgency",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Krasi's Agency" });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "CreationDate", "IsActive", "LocationJson", "Name", "OrderMeAgencyId", "UserId" },
                values: new object[] { 1, new DateTime(2024, 4, 14, 12, 1, 51, 962, DateTimeKind.Utc).AddTicks(3318), true, "[42.69397924906779,23.316393450495653]", "FreshRestau", null, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "AddedOn", "GarageId", "ImageUrl", "IsUsed", "LicensePlate", "Make", "Model" },
                values: new object[] { 1, new DateTime(2024, 4, 14, 12, 1, 51, 965, DateTimeKind.Utc).AddTicks(7362), null, "https://cdn.motor1.com/images/mgl/EMnA3/s1/2020-mercedes-amg-gt-r-driving-notes.jpg", true, "CB 8888 MK", "Mercedes-Benz", "AMG GT R" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderMeAgency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
