using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public class MonthlyBudgetPlan : IOperation
    {
        public string Name => "Free cash";

        public List<string> Type => new List<string>()
        {
            "Normal",
            "Forecasted"
        };

        public decimal Calculate(string type, decimal cost, decimal takings, string months)
        {
            decimal savings = takings - cost;
            return savings;
        }
        
    }
}
