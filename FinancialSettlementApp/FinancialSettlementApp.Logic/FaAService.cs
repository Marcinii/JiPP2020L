using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public class FaAService
    {
        public List<IOperation> GetOperations()
        {
            return new List<IOperation>()
            {
                new GeneralRules(),
                new FlatTax(),
                new MonthlyBudgetPlan()
            };
        }
    }
}
