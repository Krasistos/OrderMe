﻿using Microsoft.AspNetCore.Identity;
using OrderMe.Infrastructure.Data.Models;
using static OrderMe.Infrastructure.Constants.CustomClaims;
using System;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;

namespace OrderMe.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUserClaim<string> GuestUserClaim { get; set; }
        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public ApplicationUser GuestUser { get; set; }
        public ApplicationUser AdminUser { get; set; }

        public Cart Cart { get; set; }

        public Driver Driver { get; set; }

        public Garage Garage { get; set; }

        public MenuItem MenuItem { get; set; }

        public OrderMeAgency OrderMeAgency { get; set; }

        public Restaurant Restaurant { get; set; }

        public Vehicle Vehicle { get; set; }

        public SeedData()
        {
            // Initialize seed methods
            SeedUsers();
            SeedCart();
            SeedDriver();
            SeedGarage();
            SeedMenuItem();
            SeedOrderMeAgency();
            SeedRestaurant();
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

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "Kurzaushev098@");
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

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");
            AdminUser.EmailConfirmed = true;

        }

        private void SeedCart()
        {
            Cart = new Cart { Id = 1, UserId = GuestUser.Id };
        }

        private void SeedDriver()
        {
            Driver = new Driver { Id = 1, UserId = GuestUser.Id, IsActive = true, CreatedAt = DateTime.UtcNow };
        }

        private void SeedGarage()
        {
            Garage = new Garage { Id = 1, UserId = GuestUser.Id, Name = "FastGarage", LocationArray = new double[] { 42.713754697211016, 23.302001953125 }, IsActive = true, CreationDate = DateTime.UtcNow };
        }

        private void SeedOrderMeAgency()
        {
            OrderMeAgency = new OrderMeAgency { Id = 1, Name = "Krasi's Agency" };
        }

        private void SeedRestaurant()
        {
            Restaurant = new Restaurant { Id = 1, UserId = GuestUser.Id, Name = "FreshRestau", LocationArray = new double[] { 42.69397924906779, 23.316393450495653 }, IsActive = true, CreationDate = DateTime.UtcNow };
        }

        private void SeedMenuItem()
        {
            var imageData = LoadImageDataFromFile("../menuItemFirst.jpg");

            MenuItem = new MenuItem {
                Id = 1
                , Name = "Pancakes"
                , Description = "Tasty, with butter on top and some cream"
                , Price = 10.99m, Quantity = 1
                , ImageData = imageData
                , ImageFile = new FormFile(new MemoryStream(imageData), 0, imageData.Length, "ImageFile", "menuItemFirst.jpg")
            };
        }

        private void SeedVehicle()
        {
            var imageData = LoadImageDataFromFile("../vehicleFirst.jpg");

            Vehicle = new Vehicle { 
                Id = 1
                , LicensePlate = "CB 8888 MK"
                , Make = "Mercedes-Benz"
                , Model = "AMG GT R"
                , IsUsed = true
                , AddedOn = DateTime.UtcNow
                ,ImageData = imageData
                ,ImageFile = new FormFile(new MemoryStream(imageData), 0, imageData.Length, "ImageFile", "vehicleFirst.jpg")
            };
        }

        public byte[] LoadImageDataFromFile(string imagePath)
        {
            byte[] imageData;

            // Read image file and convert to byte array
            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }

            return imageData;
        }

    }
}
