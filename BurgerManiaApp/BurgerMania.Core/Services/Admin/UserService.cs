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

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<UserServiceModel>> All()
        {
            return await repo.AllReadonly<User>()
                .Select(u => new UserServiceModel
                {
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();
        }
    }
}
