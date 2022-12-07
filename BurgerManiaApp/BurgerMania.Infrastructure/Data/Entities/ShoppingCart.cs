﻿using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerManiaApp.Infractructure.Data.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart(string buyerId)
        {
            BuyerId = buyerId;
            DateOfCreation = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }

        public string BuyerId { get; set; }

        [ForeignKey(nameof(BuyerId))]
        public User Buyer{ get; set; }

        public List<ShoppingCartItem> CartProducts { get; set; } = new List<ShoppingCartItem>();

        public DateTime DateOfCreation { get; set; }

        public void AddItem(Product product, int quantity = 1)
        {
            if (!CartProducts.Any(i => i.ProductName == product.Name)) 
            {
                CartProducts.Add(new ShoppingCartItem(product.Id, product.Name, product.Price, product.ImageUrl, quantity));
                return;
            }


            var duplicateProducts = CartProducts.First(i => i.ProductId == product.Id);
            duplicateProducts.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            CartProducts.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewBuyerId(string buyerId)
        {
            BuyerId = buyerId;
        }
    }
}

