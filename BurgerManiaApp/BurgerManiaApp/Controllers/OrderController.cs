using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Order;
using BurgerManiaApp.Extensions;
using Microsoft.AspNetCore.Mvc;



namespace BurgerManiaApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService orderService,
            ICartService cartService)
        {
            this.orderService = orderService;
            this.cartService = cartService;
        }

        public async Task<IActionResult> All(OrdersViewModel model)
        {
            var userId = HttpContext.GetUserId();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model = await orderService.GetAllOrders(userId);

            return View(model);
        }

        public async Task<IActionResult> MoreAbout(int id)
        {
            var userId = HttpContext.GetUserId();

            var order = await orderService.GetCurrentOrderInfo(id, userId);

            return View(order);
        }

        public async Task<IActionResult> CreateOrder()
        {
            var userId = HttpContext.GetUserId();
            CheckoutViewModel model = new CheckoutViewModel
            {
                UserCart = await cartService.GetOrCreateCart(userId)
            };

            if (model.UserCart.CartItems.Count() < 1)
            {
                return RedirectToAction("Index", "Cart");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var userId = HttpContext.GetUserId();
            var cart = await cartService.GetOrCreateCart(userId);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

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
