using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using System.Collections.Generic;

namespace Dealertrack.Infrastructure.Core.DataRepository.Repository
{
    public interface IDealsDataRepository
    {
        IList<DealDataModel> GetDealData();
        void SaveDealsData(IList<DealDataModel> dealsData);

    }
}
