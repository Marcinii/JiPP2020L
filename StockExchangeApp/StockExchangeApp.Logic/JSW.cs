using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
   public  class JSW : IStock
    {
        public string Name => "JSW";
        public string Country => "PL";

        public decimal Commission(int numberOfStocks, int typeOfTransaction)
        {
            decimal[][] arrayOfCommissions =
                {
                    new decimal[] {0.005M, 0.01M}, //below 10 stocks: buy, sell
                    new decimal[] {0.0005M, 0.005M} // above 10 stocks: buy, sell
                };
            if (numberOfStocks < 10)
                return numberOfStocks * arrayOfCommissions[0][typeOfTransaction];
            else
                return numberOfStocks * arrayOfCommissions[1][typeOfTransaction];
        }
    }
}
