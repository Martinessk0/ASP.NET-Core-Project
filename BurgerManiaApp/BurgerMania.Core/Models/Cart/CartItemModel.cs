using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Cart
{
    public class CartItemModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }
    }
}
