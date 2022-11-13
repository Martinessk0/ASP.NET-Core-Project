//using BurgerManiaApp.Data.Entities.Item;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace BurgerManiaApp.Data.Configuration
//{
//    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
//    {
//        public void Configure(EntityTypeBuilder<Category> builder)
//        {
//            builder.HasData(SeedCategories());
//        }
//        private List<Category> SeedCategories()
//        {
//            var categories = new List<Category>();

//            var category = new Category()
//            {
//                Id = 1,
//                Name = "Burger"
//                Description = ""
//            };


//            categories.Add(category);

//            category = new Category()
//            {
//                Id = 2,
//                Name = "Drink"
//                Description = ""
//            };

//            categories.Add(category);

//            category = new Category()
//            {
//                Id = 3,
//                Name = "Fries"
//                Description = ""
//            };

//            categories.Add(category);

//            category = new Category()
//            {
//                Id = 4,
//                Name = "Salad"
//                Description = ""
//            };

//            categories.Add(category);

//            return categories;
//        }
//    }
//}

