using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialSettlementApp.Logic
{
    public class Cost
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Month { get; set; }
        public string Description { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}
