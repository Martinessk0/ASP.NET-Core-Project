using BurgerManiaApp.Core.Contracts.Deliverer;
using BurgerManiaApp.Core.Models.Deliverer;
using BurgerManiaApp.Core.Models.Order;
using BurgerManiaApp.Core.Models.Products;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.Core.Services.Deliverer
{
    public class DelivererOrderService : IDelivererOrderService
    {
        private readonly IRepository repo;

        public DelivererOrderService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task ChangeStatusToOrder(int id, string orderStatus)
        {
            int orderStatusId = -1;
            var order = await repo.AllReadonly<Order>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var orderStatuses = await repo.AllReadonly<OrderStatus>()
                .ToListAsync();

            foreach (var item in orderStatuses)
            {
                if (item.Name == orderStatus)
                {
                    orderStatusId = item.Id;
                    continue;
                }
            }

            if (order != null)
            {
                order.OrderStatusId = orderStatusId;
            }
            repo.Update(order);

            await repo.SaveChangesAsync();
        }

        public async Task<AllOrdersViewModel> GetAllOrders()
        {
            var result = new AllOrdersViewModel();

            var orders = await repo.AllReadonly<Order>()
                .Where(o => o.OrderStatusId != 3 && o.OrderStatusId != 4)
                .Select(o => new OrderModel()
                {
                    OrderId = o.Id,
                    OrderDate = o.OrderDate.ToString(),
                    OrderStatusId = o.OrderStatusId,
                    OrderStatusName = o.OrderStatus.Name,
                })
                .OrderByDescending(x => x.OrderId)
                .ToListAsync();

            result.Orders.AddRange(orders);

            return result;
        }

        public async Task<List<string>> GetAllOrderStatuses()
        {
            var result = new List<string>();

            var statuses = await repo.AllReadonly<OrderStatus>()
                .ToListAsync();


            foreach (var item in statuses)
            {
                result.Add(item.Name);
            }

            return result;
        }

        public ChangeStatusModel GetModel(int id)
        {
            var result = new ChangeStatusModel()
            {
                Id = id,
                Statuses = this.GetAllOrderStatuses().Result,
            };

            return result;
        }
    }
}
