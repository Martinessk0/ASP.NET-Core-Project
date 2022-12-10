using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Deliverer
{
    public class ChangeStatusModel
    {
        public int Id { get; set; }
        public List<string> Statuses { get; set; } = new List<string>();
        public string Status { get; set; } = null!;
    }
}
