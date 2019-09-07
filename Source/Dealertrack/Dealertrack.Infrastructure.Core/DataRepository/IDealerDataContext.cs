using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Infrastructure.Core.DataRepository
{
    public interface IDealerDataContext 
    {
        IList<DealDataModel> GetData();
        void SaveData(IList<DealDataModel> dealData) ;
    }
}
