using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PowerConversion : IConverter
    {
        public List<string> units = new List<string> { "W", "KM" };
        private string converterName = "Moc";
        private string result;

        public string ConverterName { get => converterName; }

        public string Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public string onConvert(string value, string unitFrom, string unitTo)
        {
            double quantity = Convert.ToDouble(value);
            if (unitFrom == "W" && unitTo == "KM") { this.Result = PowerService.fromWatToKm(quantity).ToString(); }
            else if (unitFrom == unitTo) { this.Result = quantity.ToString(); }
            else if (unitFrom == "KM" && unitTo == "W") { this.Result = PowerService.fromKmToWat(quantity).ToString(); }
            else { return null; }

            return result;
        }
    }
}
