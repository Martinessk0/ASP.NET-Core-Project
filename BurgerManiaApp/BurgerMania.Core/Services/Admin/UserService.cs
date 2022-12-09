using BurgerManiaApp.Core.Contracts.Admin;
using BurgerManiaApp.Core.Models.Admin;
using BurgerManiaApp.Core.Models.Order;
using BurgerManiaApp.Infractructure.Data.Common;
using BurgerManiaApp.Infractructure.Data.Entities.Account;
using BurgerManiaApp.Infrastructure.Data.Entities;
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

        //public async Task<IEnumerable<UserServiceModel>> All()
        //{
        //    return await repo.AllReadonly<User>()
        //        .Select(u => new UserServiceModel
        //        {
        //            Email = u.Email,
        //            FullName = $"{u.FirstName} {u.LastName}",
        //            PhoneNumber = u.PhoneNumber,
        //        })
        //        .ToListAsync();
        //}

        public async Task<UsersViewModel> All()
        {
            var result = new UsersViewModel();

            var users = await repo.AllReadonly<User>()
                .Select(o => new UserServiceModel()
                {
                    Email = o.Email,
                    FullName = $"{o.FirstName} {o.LastName}",
                    PhoneNumber = o.PhoneNumber,
                })
                .OrderBy(x => x.Email)
                .ToListAsync();

            result.Users.AddRange(users);

            return result;
        }
    }
}
