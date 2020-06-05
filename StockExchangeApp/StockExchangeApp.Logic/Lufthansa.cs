using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
    class Lufthansa: IStock
    {
        public string Name => "Lufthansa";
        public string Country => "DE";

        public decimal Commission(int numberOfStocks, int typeOfTransaction)
        {
            decimal[][] arrayOfCommissions =
                {
                    new decimal[] {0.1M, 0.05M}, //below 10 stocks: buy, sell
                    new decimal[] {0.01M, 0.05M} // above 10 stocks: buy, sell
                };
            if (numberOfStocks < 10)
                return numberOfStocks * arrayOfCommissions[0][typeOfTransaction];
            else
                return numberOfStocks * arrayOfCommissions[1][typeOfTransaction];
        }
    }
}
