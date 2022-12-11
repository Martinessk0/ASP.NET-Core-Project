using BurgerManiaApp.Core.Contracts.Deliverer;
using BurgerManiaApp.Core.Models.Deliverer;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Areas.Deliverer.Controllers
{
    public class OrderController : DelivererController
    {
        private readonly IDelivererOrderService orderService;

        public OrderController(IDelivererOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> All(AllOrdersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await orderService.GetAllOrders();
                return View(model);
            }
            model = await orderService.GetAllOrders();

            return View(model);
        }

        public IActionResult ChangeStatus(int id)
        {
            var model = orderService.GetModel(id);

            return View(model);
        }

        public async Task<IActionResult> ChangeStatusToOrder(int id,string status)
        {
            await orderService.ChangeStatusToOrder(id, status);

            return RedirectToAction("All", "Order");
        }
    }
}
