using Dealertrack.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Domain
{
    public class VehicleSales : IVehicle
    {
        public string Name { get; set; }
        public int UnitSold { get; set; }
    }
}
