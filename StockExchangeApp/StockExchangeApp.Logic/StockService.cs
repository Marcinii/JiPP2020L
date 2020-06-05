using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
    public class StockService
    {
        public List<IStock> GetStocksList(string country)
        {
            if (country.Equals("PL"))
            {
                return new List<IStock>()
                {
                    new JSW(),
                    new Orlen(),
                    new Pge()
                };
            }
            else if (country.Equals("DE"))
            {
                return new List<IStock>()
                {
                    new Lufthansa()
                };
            }
            else if (country.Equals("US"))
            {
                return new List<IStock>()
                {
                    new Uber()
                };
            }
            else
                return new List<IStock>()
                {
                    new Uber(),
                    new JSW(),
                    new Orlen(),
                    new Pge(),
                    new Lufthansa()
                };
        }
        
        public List<string> GetCountriesList()
        {
            return new List<string>()
            {
                new Uber().Country,
                new JSW().Country,
                new Orlen().Country,
                new Pge().Country,
                new Lufthansa().Country
            };
        }
    }
}
