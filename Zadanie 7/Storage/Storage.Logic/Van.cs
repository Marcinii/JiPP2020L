using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage.Logic
{
    class Van : IStorageLogicApp
    {
        public string type => "Van";

        public List<string> company => new List<string>()
        {
            "Citroen",
            "Fiat",
            "Hyundai",
            "Mercedes-benz",
            "Toyota",
            "Ford",

        };

        public int Tax => 12;

        public double CountInsurance(int Tax, double capacity, double value)
        {
            value += (value * (Tax) * capacity * capacity) / 650;
            return value;
        }
    }
}
