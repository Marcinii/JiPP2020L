using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public class GeneralRules : IOperation
    {
        public string Name => "General Rules";

        public List<string> Type => new List<string>()
        {
            "Normal",
            "Start relief"
        };

        public decimal Calculate(string type, decimal cost, decimal takings, string months)
        {
            Calculations calculations = new Calculations();
            int monthNumber = calculations.Months.IndexOf(months) + 1;
            decimal socialContributions = calculations.SocialContributions(monthNumber, type);
            decimal healthCareContribution = calculations.HealthCareContribution(monthNumber);
            decimal decreasingAmount = 525.12m / 12m;
            decimal profit = takings - cost - socialContributions - decreasingAmount;
            decimal incomeTax = profit * 0.17m;
            decimal incomeTaxToPay = incomeTax - healthCareContribution;
            return incomeTaxToPay;
        }
    }
}
