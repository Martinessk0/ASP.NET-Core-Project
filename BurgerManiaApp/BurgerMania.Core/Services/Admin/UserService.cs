using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Models.Admin;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BurgerManiaApp.Core.Services.Admin
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly UserManager<User> userManager;

        public UserService(IRepository repo,
            UserManager<User> userManager)
        {
            this.repo = repo;
            this.userManager = userManager;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            return await repo.AllReadonly<User>()
                .Select(u => new UserServiceModel
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber
                })
                .ToListAsync();

        }

        public async Task<string> UserFullName(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);
            return $"{user.FirstName} {user.LastName}".Trim();
        }
    }
}
