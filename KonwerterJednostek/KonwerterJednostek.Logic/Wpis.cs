using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Wpis
    {
        public int Id { get; set; }
        public string ConverterName { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public DateTime Data { get; set; }
        public decimal ValueFrom { get; set; }
        public string ValueTo { get; set; }
        
    }

    
}
