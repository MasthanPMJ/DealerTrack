using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealertrack.Infrastructure.Core.DataRepository.Repository;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using Dealertrack.Infrastructure.Core.DataRepository;

namespace Dealertrack.Infrastructure
{
    public class DealsDataRepositoy : IDealsDataRepository
    {
        private readonly IDealerDataContext _dataContext;
        public DealsDataRepositoy(IDealerDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IList<DealDataModel> GetDealData()
        {
            return _dataContext.GetData();
        }

        public void SaveDealsData(IList<DealDataModel> dealsData)
        {
            _dataContext.SaveData(dealsData);
        }

      
    }
}
