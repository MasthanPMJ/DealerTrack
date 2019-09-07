using System;
using System.Linq;
using System.Collections.Generic;
using Dealertrack.Domain.Service.Core;
using Dealertrack.Infrastructure.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Dealertrack.Domain.Service.Test
{
    [TestClass]
    public class DealertrackDomainServiceTest
    {
        private readonly Mock<IDealsInfrastructureService> _dealsInfraService
                 = new Mock<IDealsInfrastructureService>();
        private IDealsService _dealsService;
        IList<IDeal> deals;
        IList<VehicleSales> vehicleSales;
        [TestInitialize]
        public void Initialize()
        {
            
            #region "Mock Deal data"
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
            deals.Add(new Deal
            {
                CustomerName = "Rahima Skinner",
                DealershipName = "Seven Star Dealership",
                DealNumber = 5132,
                Price = 169900,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2009 Lamborghini Gallardo Carbon Fiber LP-560"
            });
            deals.Add(new Deal
            {
                CustomerName = "Richard Spencer",
                DealershipName = "Sun of Saskatoon",
                DealNumber = 5212,
                Price = 134599,
                SoldDate = DateTime.Now.AddDays(-2).Date,
                Vehicle = "2009 Lamborghini Gallardo Carbon Fiber LP-560"
            });
            #endregion

            _dealsService = new DealsService(_dealsInfraService.Object);
            _dealsInfraService.Setup(_ => _.GetDealData()).Returns(deals);
        }
        [TestMethod]
        public void GetVehicleSalesByUnitTest()
        {

            // Arrange
            #region "Mock Vehicle Sale data"
            vehicleSales = new List<VehicleSales>();
            vehicleSales.Add(new VehicleSales
            {
                Name = "2009 Lamborghini Gallardo Carbon Fiber LP-560",
                UnitSold = 2
            });
            vehicleSales.Add(new VehicleSales
            {
                Name = "2017 Ferrari 488 Spider",
                UnitSold = 1
            });
            vehicleSales.Add(new VehicleSales
            {
                Name = "2016 Porsche 911 2dr Cpe GT3 RS",
                UnitSold = 1
            });
            #endregion

            //Act
            var data = _dealsService.GetVehicleSalesByUnit(true);
            var vehicleSalesSorted = vehicleSales.OrderByDescending(_ => _.UnitSold).OrderBy(_ => _.Name);


            var dataJson = JsonConvert.SerializeObject(data);
            var vehicleSalesJson = JsonConvert.SerializeObject(vehicleSalesSorted);
            //Assert
            Assert.AreEqual(dataJson, vehicleSalesJson);
        }

        [TestMethod]
        public void GetDealsTest()
        {
            //Act
            var data = _dealsService.GetDealData();
            var dataJson = JsonConvert.SerializeObject(data);
            var dealsJson = JsonConvert.SerializeObject(deals);

            //Assert
            Assert.AreEqual(dataJson, dealsJson);
        }
        
    }
}
