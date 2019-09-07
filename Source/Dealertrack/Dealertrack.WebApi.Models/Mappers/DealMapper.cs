using Dealertrack.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Dealertrack.WebApi.Models.Mappers
{
    public static class DealMapper
    {
        public static IDeal ToDomain(this DealApiModel dealApiModel)
        {
            return new Deal()
            {
                CustomerName = dealApiModel.CustomerName,
                DealershipName = dealApiModel.DealershipName,
                DealNumber = dealApiModel.DealNumber,
                Price = dealApiModel.Price,
                SoldDate = dealApiModel.SoldDate,
                Vehicle = dealApiModel.Vehicle
            };
        }
        public static DealApiModel ToModel(this IDeal deal)
        {
            return new DealApiModel()
            {
                CustomerName = deal.CustomerName,
                DealershipName = deal.DealershipName,
                DealNumber = deal.DealNumber,
                Price = deal.Price,
                SoldDate = deal.SoldDate,
                Vehicle = deal.Vehicle
            };
        }
        public static List<IDeal> ToDealList(string dealsCsv)
        {

                var data = dealsCsv.Split('\n');
                var deals = new List<IDeal>();
                for (int i = 1; i < data.Length; i++)
                {
                    if (!string.IsNullOrEmpty(data[i]))
                    {
                        var deal = new Deal();
                        var input = data[i].Replace("\r", string.Empty);
                        string[] result = Regex.Split(input, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                        deal.DealNumber = int.Parse(result[0].Replace("\"", string.Empty));
                        deal.CustomerName = result[1].Replace("\"", string.Empty);
                        deal.DealershipName = result[2].Replace("\"", string.Empty);
                        deal.Vehicle = result[3].Replace("\"", string.Empty);
                        deal.Price = decimal.Parse(result[4].Replace("\"", string.Empty).Replace(",", string.Empty));
                        deal.SoldDate = DateTime.ParseExact(result[5], "M/d/yyyy", CultureInfo.InvariantCulture);
                        deals.Add(deal);

                    }
                }
                return deals;
           

           
        }
    }
}
 
