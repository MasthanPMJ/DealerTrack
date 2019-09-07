using Dealertrack.Domain;
using System.Collections.Generic;

namespace Dealertrack.Infrastructure.Core.Service
{
    public interface IDealsInfrastructureService
    {
        IList<IDeal> GetDealData();
        void SaveDealsData(IList<IDeal> dealsData);
    }
}
