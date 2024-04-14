using Microsoft.AspNetCore.Identity;
using OrderMe.Infrastructure.Data.Models;
using static OrderMe.Infrastructure.Constants.CustomClaims;

namespace OrderMe.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public ApplicationUser GuestUser { get; set; }
        public ApplicationUser AdminUser { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCart();
            SeedDriver();
            SeedFoodOrder();
            SeedGarage();
            SeedMenuItem();
            SeedOrderMeAgency();
            SeedRestaurant();
            SeedRideOrder();
            SeedVehicle();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov"
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Guest Guestov",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(GuestUser, "Kurzaushev098@");
            GuestUser.EmailConfirmed = true;


            AdminUser = new ApplicationUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin"
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 3,
                ClaimType = UserFullNameClaim,
                UserId = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                ClaimValue = "Great Admin"
            };

            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
            AdminUser.EmailConfirmed = true;

        }

        private void SeedCart()
        {
            // Seed Cart model entities
            // Example: 
            // var carts = new List<Cart>
            // {
            //     new Cart { UserId = "userId1" },
            //     new Cart { UserId = "userId2" }
            // };

            // Add additional setup for carts if needed
        }

        private void SeedDriver()
        {
            // Seed Driver model entities
            // Example: 
            // var drivers = new List<Driver>
            // {
            //     new Driver { UserId = "userId1", IsActive = true, CreatedAt = DateTime.UtcNow }
            // };

            // Add additional setup for drivers if needed
        }

        private void SeedFoodOrder()
        {
            // Seed FoodOrder model entities
            // Example: 
            // var foodOrders = new List<FoodOrder>
            // {
            //     new FoodOrder { CartId = 1, UserId = "userId1", RestaurantId = 1, DriverId = 1, VehicleId = 1, DestinationArray = new double[] { 12.34, 56.78 } }
            // };

            // Add additional setup for food orders if needed
        }

        private void SeedGarage()
        {
            // Seed Garage model entities
            // Example: 
            // var garages = new List<Garage>
            // {
            //     new Garage { UserId = "userId1", Name = "Garage1", LocationArray = new double[] { 12.34, 56.78 }, IsActive = true, CreationDate = DateTime.UtcNow }
            // };

            // Add additional setup for garages if needed
        }

        private void SeedMenuItem()
        {
            // Seed MenuItem model entities
            // Example: 
            // var menuItems = new List<MenuItem>
            // {
            //     new MenuItem { Name = "Item1", Description = "Description1", Price = 10.99m, Quantity = 2, ImageUrl = "https://example.com/image1.jpg" }
            // };

            // Add additional setup for menu items if needed
        }

        private void SeedOrderMeAgency()
        {
            // Seed OrderMeAgency model entities
            // Example: 
            // var orderMeAgencies = new List<OrderMeAgency>
            // {
            //     new OrderMeAgency { Name = "Agency1" }
            // };

            // Add additional setup for order me agencies if needed
        }

        private void SeedRestaurant()
        {
            // Seed Restaurant model entities
            // Example: 
            // var restaurants = new List<Restaurant>
            // {
            //     new Restaurant { UserId = "userId1", Name = "Restaurant1", LocationArray = new double[] { 12.34, 56.78 }, IsActive = true, CreationDate = DateTime.UtcNow }
            // };

            // Add additional setup for restaurants if needed
        }

        private void SeedRideOrder()
        {
            // Seed RideOrder model entities
            // Example: 
            // var rideOrders = new List<RideOrder>
            // {
            //     new RideOrder { UserId = "userId1", DriverId = 1, VehicleId = 1, PickUpLocationArray = new double[] { 12.34, 56.78 }, DropOffLocationArray = new double[] { 12.34, 56.78 }, SceduledFor = DateTime.UtcNow }
            // };

            // Add additional setup for ride orders if needed
        }

        private void SeedVehicle()
        {
            // Seed Vehicle model entities
            // Example: 
            // var vehicles = new List<Vehicle>
            // {
            //     new Vehicle { LicensePlate = "ABC123", Make = "Toyota", Model = "Camry", IsUsed = true, AddedOn = DateTime.UtcNow }
            // };

            // Add additional setup for vehicles if needed
        }
    }
}
