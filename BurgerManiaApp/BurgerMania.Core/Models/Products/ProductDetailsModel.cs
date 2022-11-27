using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerManiaApp.Core.Models.Products
{
    public class ProductDetailsModel : ProductServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
