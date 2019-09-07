using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Domain
{
    public class Deal: IDeal
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
