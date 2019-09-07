using System;
using System.Collections.Generic;
using Dealertrack.Infrastructure.Core.DataRepository;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using Dealertrack.Infrastructure.Core.DataRepository.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Dealertrack.Infrastructure.Test
{
    [TestClass]
    public class TestDealertrackInfrastructureRepository
    {
        private readonly Mock<IDealerDataContext> _delerDataContext
          = new Mock<IDealerDataContext>();
        private   IDealsDataRepository dealsDataRepository;
        IList<DealDataModel> deals;
        [TestInitialize]
        public void Initialize()
        {
            deals = new List<DealDataModel>();
            deals.Add(new DealDataModel
            {
                CustomerName = "Aroush Knapp",
                DealershipName = "Maxwell & Junior",
                DealNumber = 5132,
                Price = 289900,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2016 Porsche 911 2dr Cpe GT3 RS"
            });
            deals.Add(new DealDataModel
            {
                CustomerName = "Milli Fulton",
                DealershipName = "Sun of Saskatoon",
                DealNumber = 5469,
                Price = 429987,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2017 Ferrari 488 Spider"
            });
            dealsDataRepository = new DealsDataRepositoy(_delerDataContext.Object);
            _delerDataContext.Setup(_ => _.GetData()).Returns(deals);
            _delerDataContext.Setup(_ => _.SaveData(It.IsAny<IList<DealDataModel>>()));


        }
        [TestMethod]
        public void TestSaveData()
        {
            //Act
              dealsDataRepository.SaveDealsData(deals);
            //Assert
            _delerDataContext.Verify(_ => _.SaveData(deals), Times.Once);
            
        }
        [TestMethod]
        public void TestGetData()
        {
            //Act
            var data = dealsDataRepository.GetDealData();
            //Assert
            Assert.AreEqual(data, deals);
        }
    }
}
