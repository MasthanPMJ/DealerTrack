using Moq;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Dealertrack.Domain;
using Dealertrack.Infrastructure.Service;
using Dealertrack.Infrastructure.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dealertrack.Infrastructure.Core.DataRepository.DataModel;
using Dealertrack.Infrastructure.Core.DataRepository.Repository;

namespace Dealertrack.Infrastructure.Test
{
    [TestClass]
    public class TestDealertrackInfrastructureService
    {
        private readonly Mock<IDealsDataRepository> _dealerDataRepository
                 = new Mock<IDealsDataRepository>();
        private IDealsInfrastructureService _dealsInfrastructureService;
        IList<DealDataModel> dealsModel;
        IList<IDeal> deals;
        [TestInitialize]
        public void Initialize()
        {
            dealsModel = new List<DealDataModel>();
            dealsModel.Add(new DealDataModel
            {
                CustomerName = "Aroush Knapp",
                DealershipName = "Maxwell & Junior",
                DealNumber = 5132,
                Price = 289900,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2016 Porsche 911 2dr Cpe GT3 RS"
            });
            dealsModel.Add(new DealDataModel
            {
                CustomerName = "Milli Fulton",
                DealershipName = "Sun of Saskatoon",
                DealNumber = 5469,
                Price = 429987,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2017 Ferrari 488 Spider"
            });

            deals = new List<IDeal>();
            deals.Add(new Deal
            {
                CustomerName = "Aroush Knapp",
                DealershipName = "Maxwell & Junior",
                DealNumber = 5132,
                Price = 289900,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2016 Porsche 911 2dr Cpe GT3 RS"
            });
            deals.Add(new Deal
            {
                CustomerName = "Milli Fulton",
                DealershipName = "Sun of Saskatoon",
                DealNumber = 5469,
                Price = 429987,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2017 Ferrari 488 Spider"
            });

            _dealsInfrastructureService = new DealsInfrastructureService(_dealerDataRepository.Object);
            _dealerDataRepository.Setup(_ => _.GetDealData()).Returns(dealsModel);
            _dealerDataRepository.Setup(_ => _.SaveDealsData(It.IsAny<IList<DealDataModel>>()));


        }
        [TestMethod]
        public void TestGetData()
        {
            //Act
            var data = _dealsInfrastructureService.GetDealData();

            var dataJson = JsonConvert.SerializeObject(data);
            var dealsJson = JsonConvert.SerializeObject(deals);


            //Assert
            Assert.AreEqual(dataJson, dealsJson);
        }
    }
}
