using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Cart;
using BurgerManiaApp.Core.Services;
using BurgerManiaApp.Extensions;
using BurgerManiaApp.Helper;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(
            ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.GetUserId();
            var cart = await cartService.GetOrCreateCart(userId);

            IndexViewModel model = new IndexViewModel
            {
                UserCart = cart
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int Id)
        {
            var userId = HttpContext.GetUserId();
            await cartService.GetOrCreateCart(userId);

            await cartService.AddToCart(userId, Id);

            return RedirectToAction("All", "Product");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCart(Dictionary<int, int> productAndQuantity)
        {
            if (productAndQuantity.Values.Any(x => x < 0))
            {
                TempData["NegativeQuantityError"] = "Quantity cannot be negative";

                return RedirectToAction("Index");
            }

            await cartService.UpdateQuantity(productAndQuantity);

            return RedirectToAction("Index");
        }
    }
}
