using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
    public class Pge: IStock
    {
        public string Name => "PGE";
        public string Country => "PL";

        public decimal Commission(int numberOfStocks, int typeOfTransaction)
        {
            decimal[][] arrayOfCommissions =
                {
                    new decimal[] {0.02M, 0.01M}, //below 10 stocks: buy, sell
                    new decimal[] {0.002M, 0.01M} // above 10 stocks: buy, sell
                };
            if (numberOfStocks < 10)
                return numberOfStocks * arrayOfCommissions[0][typeOfTransaction];
            else
                return numberOfStocks * arrayOfCommissions[1][typeOfTransaction];
        }
    }
}
