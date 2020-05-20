using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Logic
{
    public class Converter
    {

        public int id { get; set; }
        public string ConveterName { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public decimal ValueStart { get; set; }
        public decimal ValueConverted { get; set; }
        public DateTime UseDate { get; set; }

        public Converter(int id, string conveterName, string unitFrom, string unitTo, decimal valueStart, decimal valueConverted, DateTime useDate)
        {
            this.id = id;
            ConveterName = conveterName ?? throw new ArgumentNullException(nameof(conveterName));
            UnitFrom = unitFrom ?? throw new ArgumentNullException(nameof(unitFrom));
            UnitTo = unitTo ?? throw new ArgumentNullException(nameof(unitTo));
            ValueStart = valueStart;
            ValueConverted = valueConverted;
            UseDate = useDate;
        }
    }
}
