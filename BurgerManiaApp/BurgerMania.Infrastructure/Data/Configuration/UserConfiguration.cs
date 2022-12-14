using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BurgerManiaApp.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(SeedUsers());
        }

        private List<User> SeedUsers()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                FirstName = "Admin",
                LastName = "Adminov",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                Address = "Admin Street 6"
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Admin123/");

            users.Add(user);

            user = new User()
            {
                Id = "06552aa5-bcbe-49ef-ac65-fd84699d0d3e",
                FirstName = "Guest",
                LastName = "Guestov",
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                Address = "Guest Street 3"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Guest123/");

            users.Add(user);

            user = new User()
            {
                Id = "f9bf120c-fafd-48d1-a4c6-330f99ad8a67",
                FirstName = "Deliverer",
                LastName = "Delivrov",
                UserName = "Deliverer",
                NormalizedUserName = "DELIVERER",
                Email = "deliverer@gmail.com",
                NormalizedEmail = "DELIVERER@GMAIL.COM",
                Address = "DELIVERER Street 5"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "Deliverer123/");

            users.Add(user);

            return users;
        }

    }
}
