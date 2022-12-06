using BurgerManiaApp.Core.Models.Admin;

namespace BurgerManiaApp.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();

    }
}
