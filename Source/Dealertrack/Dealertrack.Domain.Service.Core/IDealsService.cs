using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Domain.Service.Core
{
    public interface IDealsService
    {
        IList<IDeal> GetDealData();
        void SaveDealData(IList<IDeal> deals);
        IList<VehicleSales> GetVehicleSalesByUnit(bool unitSoldDescending);


    }
}
