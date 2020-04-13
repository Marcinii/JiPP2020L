using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Desktop
{
    public class ConverterData
    {
        public int Id { get; set; }
        public string UsedConverter { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public string InputValue { get; set; }
        public string OutputValue { get; set; }
        public DateTime? ConvertDate { get; set; }
    }
}
