using BurgerManiaApp.Core.Models.Admin;

namespace BurgerManiaApp.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<UsersViewModel> All();

    }
}
