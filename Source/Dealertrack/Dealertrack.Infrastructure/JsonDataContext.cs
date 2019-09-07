using Dealertrack.Infrastructure.Core.DataRepository;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealertrack.Infrastructure
{
    public class JsonDataContext : IDealerDataContext
    {
        private readonly string  _fileName;
        public JsonDataContext(string fileName)
        {
            _fileName = fileName;
        }
        public IList<DealDataModel> GetData()
        {
            IList<DealDataModel> deals=null;
            if (File.Exists(_fileName))
            {
                var json = File.ReadAllText(_fileName);
                var result = JsonConvert.DeserializeObject<List<DealDataModel>>(json);
                deals = result;
            }
            
            return deals;
        }

        public void SaveData(IList<DealDataModel> dealData )
        {
            var result = JsonConvert.SerializeObject(dealData);
            File.WriteAllText(_fileName, result);
        }
    }
}
