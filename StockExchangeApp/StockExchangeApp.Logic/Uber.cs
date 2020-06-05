using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
    class Uber: IStock
    {
        public string Name => "Uber";
        public string Country => "US";

        public decimal Commission(int numberOfStocks, int typeOfTransaction)
        {
            decimal[][] arrayOfCommissions =
                {
                    new decimal[] {0.1M, 0.1M}, //below 10 stocks: buy, sell
                    new decimal[] {0.2M, 0.2M} // above 10 stocks: buy, sell
                };
            if (numberOfStocks < 10)
                return numberOfStocks * arrayOfCommissions[0][typeOfTransaction];
            else
                return numberOfStocks * arrayOfCommissions[1][typeOfTransaction];
        }
    }
}
