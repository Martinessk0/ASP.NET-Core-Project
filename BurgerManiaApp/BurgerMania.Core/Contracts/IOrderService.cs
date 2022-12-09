using BurgerManiaApp.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrder(string? buyerId,
                                      int? cartId,
                                      string email,
                                      string firstName,
                                      string lastName,
                                      string phoneNumber,
                                      string zipCode,
                                      string streetAddress,
                                      string city,
                                      string? deliveryAddressName);

        Task<OrdersViewModel> GetAllOrders(string? userId);

        Task<CurrentOrderViewModel> GetCurrentOrderInfo(int id, string userId);
    }
}
