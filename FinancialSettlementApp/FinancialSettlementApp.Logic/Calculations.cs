using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public class Calculations
    {
        public decimal SocialContributions(int monthNumber, string type)
        {
            if (monthNumber == 1)
            {
                if (type == "Start relief")
                {
                    return 197.03m;
                }
                else
                {
                    return 834.55m;
                }

            }
            else
            {
                if (type == "Start relief")
                {
                    return 227.69m;
                }
                else
                {
                    return 915.46m;
                }
            }

        }

        public decimal HealthCareContribution(int monthNumber)
        {
            if (monthNumber == 1)
            {
                return 294.78m;
            }
            else
            {
                return 312.02m;
            }
        }

        public List<string> Months => new List<string>()
        {
        "January",
        "February",
        "March",
        "April",
        "May",
        "June",
        "July",
        "August",
        "September",
        "October",
        "November",
        "December"
        };
    }
}

