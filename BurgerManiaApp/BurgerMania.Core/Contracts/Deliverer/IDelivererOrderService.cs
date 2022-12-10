using BurgerManiaApp.Core.Models.Deliverer;
using BurgerManiaApp.Core.Models.Products;
using Microsoft.AspNetCore.Mvc;

namespace BurgerManiaApp.Core.Contracts.Deliverer
{
    public interface IDelivererOrderService
    {

        Task<AllOrdersViewModel> GetAllOrders();

        Task<List<string>> GetAllOrderStatuses();

        ChangeStatusModel GetModel(int id);

        Task ChangeStatusToOrder(int id, string orderStatus);

    }
}
