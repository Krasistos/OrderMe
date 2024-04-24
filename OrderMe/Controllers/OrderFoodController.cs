﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OrderMe.Core.Contracts;
using OrderMe.Core.Models.OrderFood;
using OrderMe.Core.Services;
using OrderMe.Infrastructure.Data.Models;

namespace OrderMe.Controllers
{
    public class OrderFoodController : BaseController
    {
        private readonly IOrderFoodService orderFoodService;
        private readonly ICartService cartService;


        public OrderFoodController(IOrderFoodService _orderFoodService, ICartService _cartService)
        {
            orderFoodService = _orderFoodService;
            this.cartService = _cartService;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> SubmitOrder()
        {
            var driver = orderFoodService.GetFreeDriver().Result;
            var vehicle = orderFoodService.GetFreeVehicle().Result;

            var cart = orderFoodService.CreateCart(User.Id());

            if (driver == null || vehicle == null)
            {
                return View("CannotNow");
            }

            return View("SubmitOrder", new OrderFoodForm { DriverId = driver.Id, VehicleId = vehicle.Id, Cart = cart.Result });
        }

        public async Task<IActionResult> AddMenuItemToCart(int menuItemId, Cart cart)
        {
            await cartService.AddMenuItemCart(menuItemId, cart.Id);
            return PartialView("_CartPartial", cart); // Return updated cart partial view
        }

        public async Task<IActionResult> RemoveMenuItemFromCart(int menuItemId, Cart cart)
        {
            await cartService.RemoveMenuItemFromCart(menuItemId, cart.Id);
            return PartialView("_CartPartial", cart); // Return updated cart partial view
        }

        public async Task<IActionResult> IncreaseQuantityOfMenuItem(int menuItemId, Cart cart)
        {
            await cartService.IncreaseQuantityOfMenuItem(menuItemId, cart.Id);
            return PartialView("_CartPartial", cart); // Return updated cart partial view
        }

        public async Task<IActionResult> DecreaseQuantityOfMenuItem(int menuItemId, Cart cart)
        {
            await cartService.DecreaseQuantityOfMenuItem(menuItemId, cart.Id);
            return PartialView("_CartPartial", cart); // Return updated cart partial view
        }
    }
}
