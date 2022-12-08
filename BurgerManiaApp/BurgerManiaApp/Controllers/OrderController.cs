using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Order;
using BurgerManiaApp.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;



namespace BurgerManiaApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> logger;
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private IConfiguration config;

        public OrderController(IOrderService orderService, 
            ICartService cartService,
            ILogger<OrderController> logger, 
            IConfiguration config)
        {
            this.orderService = orderService;
            this.cartService = cartService;
            this.logger = logger;
            this.config = config;
        }

        public async Task<IActionResult> CreateOrder()
        {
            var userId = HttpContext.GetUserId();
            CheckoutViewModel vm = new CheckoutViewModel
            {
                UserCart = await cartService.GetOrCreateCart(userId)
            };

            if (vm.UserCart.CartItems.Count() < 1)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userId = HttpContext.GetUserId();
            var cart = await cartService.GetOrCreateCart(userId);

            if (ModelState.IsValid)
            {
                await orderService.CreateOrder(userId,
                                             cart.Id,
                                             model.EmailAddress,
                                             model.FirstName,
                                             model.LastName,
                                             model.PhoneNumber,
                                             model.PostalCode,
                                             model.StreetAddress,
                                             model.City,
                                             model.AddressName);

                return RedirectToAction("All", "Product");
            }

            model.UserCart = await cartService.GetOrCreateCart(userId);

            return View("CreateOrder", model);
        }       
    }
}
