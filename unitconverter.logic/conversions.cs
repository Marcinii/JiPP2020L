using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class conversions
    {
        public int id { get; set; }
        public int converter { get; set; }
        public string units_from { get; set; }
        public string units_to { get; set; }
        public string value_from { get; set; }
        public string value_to { get; set; }
        public DateTime conversion_date { get; set; }
    }
}
