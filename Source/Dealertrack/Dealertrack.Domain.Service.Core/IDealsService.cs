using System.Collections.Generic;

namespace Dealertrack.Domain.Service.Core
{
    public interface IDealsService
    {
        IList<IDeal> GetDealData();
        void SaveDealData(IList<IDeal> deals);
        IList<VehicleSales> GetVehicleSalesByUnit(bool unitSoldDescending);


    }
}
