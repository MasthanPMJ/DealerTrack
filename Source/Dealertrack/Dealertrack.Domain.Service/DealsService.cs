using Dealertrack.Domain.Service.Core;
using Dealertrack.Infrastructure.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Domain.Service
{
    public class DealsService : IDealsService
    {
        private readonly IDealsInfrastructureService _dealsInfrastructureService;
        public DealsService(IDealsInfrastructureService dealsInfrastructureService)
        {
            _dealsInfrastructureService = dealsInfrastructureService;
        }
        public IList<IDeal> GetDealData()
        {
            return _dealsInfrastructureService.GetDealData();
        }

        public IList<VehicleSales> GetVehicleSalesByUnit(bool unitSoldDescending)
        {
            IList<VehicleSales> vehicleSales=null;
            var deals = _dealsInfrastructureService.GetDealData();
            if (deals != null)
            {
                var vehicles = deals.GroupBy(_ => _.Vehicle)
                    .Select(group => new
                        VehicleSales
                        {
                            Name = group.Key,
                            UnitSold = group.Count()
                        });
                if (unitSoldDescending)
                {
                    vehicleSales = vehicles.OrderByDescending(_ => _.UnitSold).ThenBy(_ => _.Name).ToList();
                }
                else
                {
                    vehicleSales = vehicles.OrderBy(_ => _.UnitSold).ThenBy(_ => _.Name).ToList();
                }
            }

            return vehicleSales;
        }

        public void SaveDealData(IList<IDeal> deals)
        {
            _dealsInfrastructureService.SaveDealsData(deals);
        }
    }
}
