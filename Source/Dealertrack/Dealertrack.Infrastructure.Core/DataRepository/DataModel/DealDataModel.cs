using System;

namespace Dealertrack.Infrastructure.Core.DataRepository.DataModel
{
    public class DealDataModel : IDealDataModel
    {
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime SoldDate { get; set; }
    }
}
