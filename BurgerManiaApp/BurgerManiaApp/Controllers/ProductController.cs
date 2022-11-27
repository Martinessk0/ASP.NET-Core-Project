using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllProductsQueryModel query)
        {
            var result = await productService.All(
               query.Category,
               query.SearchTerm,
               query.Sorting,
               query.CurrentPage,
               AllProductsQueryModel.ProductPerPage);

            query.TotalProductsCount = result.TotalProductsCount;
            query.Categories = await productService.AllCategoriesNames();
            query.Houses = result.Products;

            return View(query);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await productService.ProductDetailsById(id);

            return View(model);
        }
    }
}
