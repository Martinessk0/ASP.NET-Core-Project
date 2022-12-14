using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Infrastructure.Data.Configuration
{
    public  class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            //builder.HasData(SeedProducts());
        }

        private List<Product> SeedProducts()
        {
            var products = new List<Product>();

            var product = new Product()
            {
                Id = 1,
                Name = "Spicy Burger",
                Description = "Spicy Burger",
                ImageUrl = "https://wickedkitchen.com/wp-content/uploads/2022/05/Wicked-jalapeno-burger.jpeg",
                Price = 7,
                CategoryId = 1,
                IsActive = true,

            };

            products.Add(product);

            product = new Product()
            {
                Id = 2,
                Name = "Coca-Cola",
                Description = "Coca-Cola",
                ImageUrl = "https://cdncloudcart.com/16372/products/images/68308/coca-cola-bezalkoholna-napitka-ken-250-ml-image_629659e5b307d_1920x1920.jpeg?1654020601",
                Price = 1,
                CategoryId = 2,
                IsActive = true,

            };

            products.Add(product);

            product = new Product()
            {
                Id = 3,
                Name = "Salad with Iceberg lettuce",
                Description = "Salad with Iceberg lettuce",
                ImageUrl = "https://eatsomethingvegan.com/wp-content/uploads/2021/11/Iceberg-Lettuce-Salad-5-681x1024.jpg",
                Price = 7,
                CategoryId = 4,
                IsActive = true,

            };

            products.Add(product);


            return products;
        }
    }
}
