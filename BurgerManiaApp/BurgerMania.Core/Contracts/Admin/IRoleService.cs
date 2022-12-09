using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Contracts.Admin
{
    public interface IRoleService
    {
        List<string> GetRoles();
    }
}
