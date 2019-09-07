using Dealertrack.Domain;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Infrastructure.Mapper
{
    public static class DealMapper
    {
        public static IDeal ToDomain(this IDealDataModel dealData)
        {
            return new Deal()
            {
                CustomerName = dealData.CustomerName,
                DealershipName = dealData.DealershipName,
                DealNumber = dealData.DealNumber,
                Price = dealData.Price,
                SoldDate = dealData.SoldDate,
                Vehicle = dealData.Vehicle
            };
        }
        public static DealDataModel ToDataModel(this IDeal deal)
        {
            return new DealDataModel()
            {
                CustomerName = deal.CustomerName,
                DealershipName = deal.DealershipName,
                DealNumber = deal.DealNumber,
                Price = deal.Price,
                SoldDate = deal.SoldDate,
                Vehicle = deal.Vehicle
            };
        }
    }
}
