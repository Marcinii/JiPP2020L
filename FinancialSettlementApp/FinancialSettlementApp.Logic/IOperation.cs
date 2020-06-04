using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public interface IOperation
    {
        string Name { get; }
        List<String> Type { get; }
        
        decimal Calculate(string type, decimal cost, decimal takings, string months);
    }
}
