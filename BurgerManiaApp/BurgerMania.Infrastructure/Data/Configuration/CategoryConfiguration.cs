using BurgerManiaApp.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerManiaApp.Infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }
        private List<Category> SeedCategories()
        {
            var categories = new List<Category>();

            var category = new Category()
            {
                Id = 1,
                Name = "Burger"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Drink"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Fries"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Salad"
            };

            categories.Add(category);

            return categories;
        }
    }
}

