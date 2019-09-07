using System;

namespace Dealertrack.Infrastructure.Core.DataRepository.DataModel
{
    public interface IDealDataModel
    {
        int DealNumber { get; set; }
        string CustomerName { get; set; }
        string DealershipName { get; set; }
        string Vehicle { get; set; }
        decimal Price { get; set; }
        DateTime SoldDate { get; set; }

    }
}
