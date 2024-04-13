using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderMe.Infrastructure.Migrations
{
    public partial class fulldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Customer Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Cart");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Driver Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the driver occupied"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When did the user become a driver")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Driver");

            migrationBuilder.CreateTable(
                name: "OrderMeAgency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Agency Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Agency Name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMeAgency", x => x.Id);
                },
                comment: "OrderMe Agency");

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Menu Item Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the menu item"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Description of the menu item"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of the menu item"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "When was the menu item added"),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                },
                comment: "Menu Item");

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Garage Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Owner Identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Garage Name"),
                    LocationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Garage's location"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the garage active"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When was the garage created"),
                    OrderMeAgencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Garages_OrderMeAgency_OrderMeAgencyId",
                        column: x => x.OrderMeAgencyId,
                        principalTable: "OrderMeAgency",
                        principalColumn: "Id");
                },
                comment: "Garage");

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Restaurant Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Owner Identifier"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Restaurant Name"),
                    LocationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Restaurant's location"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, comment: "Is the garage active"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When was the restaurant created"),
                    OrderMeAgencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Restaurants_OrderMeAgency_OrderMeAgencyId",
                        column: x => x.OrderMeAgencyId,
                        principalTable: "OrderMeAgency",
                        principalColumn: "Id");
                },
                comment: "Restaurant");

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Vehicle's license plate"),
                    Make = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Vehicle's make"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Vehicle's model"),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, comment: "Is the vehicle in use"),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "When was the vehicle added"),
                    GarageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Garages_GarageId",
                        column: x => x.GarageId,
                        principalTable: "Garages",
                        principalColumn: "Id");
                },
                comment: "Vehicle");

            migrationBuilder.CreateTable(
                name: "FoodOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Food Order Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false, comment: "Cart Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User Identifier"),
                    RestaurantId = table.Column<int>(type: "int", nullable: false, comment: "Restaurant Identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver Identifier"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier"),
                    DestinationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Destination of food deliver")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodOrders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Food Order");

            migrationBuilder.CreateTable(
                name: "RideOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Ride Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Customer Identifier"),
                    DriverId = table.Column<int>(type: "int", nullable: false, comment: "Driver Identifier"),
                    VehicleId = table.Column<int>(type: "int", nullable: false, comment: "Vehicle Identifier"),
                    PickUpLocationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Pickup Location"),
                    DropOffLocationJson = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Drop off Location"),
                    SceduledFor = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The sceduled date and time for the ride")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RideOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RideOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideOrders_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RideOrders_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ride Order");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_CartId",
                table: "FoodOrders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_DriverId",
                table: "FoodOrders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_RestaurantId",
                table: "FoodOrders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_UserId",
                table: "FoodOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodOrders_VehicleId",
                table: "FoodOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_OrderMeAgencyId",
                table: "Garages",
                column: "OrderMeAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Garages_UserId",
                table: "Garages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CartId",
                table: "MenuItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OrderMeAgencyId",
                table: "Restaurants",
                column: "OrderMeAgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RideOrders_DriverId",
                table: "RideOrders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RideOrders_UserId",
                table: "RideOrders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RideOrders_VehicleId",
                table: "RideOrders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_GarageId",
                table: "Vehicles",
                column: "GarageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodOrders");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "RideOrders");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "OrderMeAgency");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
