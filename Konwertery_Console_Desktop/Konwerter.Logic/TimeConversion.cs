using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TimeConversion : IConverter
    {
        public List<string> units = new List<string> { "24", "12", };
        private string converterName = "Czas";
        private string result;

        public string Result { set => result = value; }

        public string ConverterName { get => converterName; }

        public List<string> ConverterUnits { get => units; }

        public string onConvert(string value, string unitFrom, string unitTo)
        {
            if (unitFrom == "24" && unitTo == "12") { this.Result = TimeService.fromNumericToPm(value); }
            else if (unitFrom == unitTo) { this.Result = value; }
            else if (unitFrom == "12" && unitTo == "24") { this.Result = TimeService.fromPmToNumeric(value); }
            else { return null; }

            return result;
        }
    }
}
