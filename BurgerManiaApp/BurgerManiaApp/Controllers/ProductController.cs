using static BurgerManiaApp.Areas.Admin.Constants.AdminConstants;
using BurgerManiaApp.Core.Contracts;
using BurgerManiaApp.Core.Models.Products;
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
            query.Products = result.Products;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            var model = new ProductModel()
            {
                ProductCategories = await productService.AllCategories()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            if ((await productService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            if (!ModelState.IsValid)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            int id = await productService.Create(model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            var product = await productService.ProductDetailsById(id);
            var categoryId = await productService.GetProductCategoryId(id);

            var model = new ProductModel()
            {
                CategoryId = categoryId,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Name = product.Name,
                ProductCategories = await productService.AllCategories(),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            if ((await productService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Product does not exist");

                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            if ((await productService.CategoryExists(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");

                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }
            if (ModelState.IsValid == false)
            {
                model.ProductCategories = await productService.AllCategories();

                return View(model);
            }

            await productService.Edit(model.Id, model);
            return RedirectToAction(nameof(Details), new { model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            var product = await productService.ProductDetailsById(id);
            var model = new ProductDetailsModel()
            {
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Name = product.Name
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductDetailsModel model)
        {
            if ((await productService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            if (!(this.User.IsInRole(AdminRoleName)))
            {
                return RedirectToAction("AccessDenied", "Error");
            }

            await productService.Delete(id);

            return RedirectToAction(nameof(All));
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
