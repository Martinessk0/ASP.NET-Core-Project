using BurgerManiaApp.Infractructure.Data.Entities.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Infrastructure.Data.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int CartItemId { get; set; }

        [ForeignKey(nameof(CartItemId))]
        public CartItem CartItem { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
