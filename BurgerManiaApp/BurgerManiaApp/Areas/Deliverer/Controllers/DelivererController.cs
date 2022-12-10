using static BurgerManiaApp.Areas.Deliverer.Constants.DelivererConstants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BurgerManiaApp.Areas.Deliverer.Controllers
{
    [Area(AreaName)]
    [Authorize(Roles = DelivererRoleName)]
    public class DelivererController : Controller
    {

    }
}
