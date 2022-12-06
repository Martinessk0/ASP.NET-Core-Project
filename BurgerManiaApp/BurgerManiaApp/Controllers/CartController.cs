using BurgerManiaApp.Helper;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository repo;

        public CartController(IRepository repo)
        {
            this.repo = repo;
        }

        public async IActionResult Index()
        {
            var userId = User.Identity;
            var user = await repo.GetByIdAsync<User>(userId);


            return View();
        }

        public async Task<IActionResult> AddToCart(int id) 
        {
            
            return View();
        }
    }
}
