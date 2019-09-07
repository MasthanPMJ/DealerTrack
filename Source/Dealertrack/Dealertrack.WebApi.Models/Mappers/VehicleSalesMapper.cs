using Dealertrack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.WebApi.Models.Mappers
{
    public static class VehicleSalesMapper
    {
        public static VehicleSalesApiModel ToModel(this VehicleSales vehicleSales)
        {
            return new VehicleSalesApiModel()
            {
                 Name = vehicleSales.Name,
                UnitSold = vehicleSales.UnitSold
            };
        }
    }

}
