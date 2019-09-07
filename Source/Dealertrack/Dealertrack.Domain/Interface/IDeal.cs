using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Domain
{
    public interface IDeal
    {
        int DealNumber { get; set; }
        string CustomerName { get; set; }
        string DealershipName { get; set; }
        string Vehicle { get; set; }
        decimal Price { get; set; }
        DateTime SoldDate { get; set; }
    }
}
