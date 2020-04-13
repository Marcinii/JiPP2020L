using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Conversion
    {
        public int rowId { get; set; }
        public string name { get; set; }
        public string unitFrom { get; set; }
        public string unitTo { get; set; }
        public DateTime dateOfConversion { get; set; }
        public double valueToConvert { get; set; }
        public double valueAfterConvert { get; set; }
    }
}
