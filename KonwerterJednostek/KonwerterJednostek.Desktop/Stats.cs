using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Desktop
{
    public class Stats
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public DateTime Date { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }
    }
}
