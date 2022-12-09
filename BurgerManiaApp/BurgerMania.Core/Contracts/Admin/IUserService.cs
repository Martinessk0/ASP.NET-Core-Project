using BurgerManiaApp.Core.Models.Admin;

namespace BurgerManiaApp.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<IEnumerable<UserServiceModel>> All();

    }
}
