using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeApp.Logic
{
    public interface IStock
    {
        string Name { get; }
        string Country { get; }

        decimal Commission(int numberOfStocks, int typeOfTransaction);              
    }
}
