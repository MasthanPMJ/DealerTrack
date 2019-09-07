using System.Linq;
using Dealertrack.Domain;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using Dealertrack.Infrastructure.Core.DataRepository.Repository;
using Dealertrack.Infrastructure.Core.Service;
using Dealertrack.Infrastructure.Mapper;
using System.Collections.Generic;

namespace Dealertrack.Infrastructure.Service
{
    public class DealsInfrastructureService : IDealsInfrastructureService
    {
        private readonly IDealsDataRepository _dealsDataRepository;
        public DealsInfrastructureService(IDealsDataRepository dealsDataRepository)
        {
            _dealsDataRepository = dealsDataRepository;
        }

        public IList<IDeal> GetDealData()
        {
            IList<IDeal> result =null;
            var data = _dealsDataRepository.GetDealData();
            if(data!= null)
                result= data.Select(_ => _.ToDomain()).ToList();

            return result;
        }

        public void SaveDealsData(IList<IDeal> dealsData)
        {
           var dataModel= dealsData.Select(_=> _.ToDataModel()).ToList();
            _dealsDataRepository.SaveDealsData(dataModel);
        }
    }
}
