using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BurgerManiaApp.Areas.Admin.Constants.AdminConstants;

namespace BurgerManiaApp.Areas.Admin.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
      
    }
}
