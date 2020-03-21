using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TemperatureConversion : IConverter
    {
        public List<string> units = new List<string> { "C", "F", "K" };
        private string converterName = "Temperatura";
        private string result;

        public string ConverterName { get => converterName; }

        public string Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public string onConvert(string value, string unitFrom, string unitTo)
        {
            double quantity = Convert.ToDouble(value);
            if (unitFrom == "C" && unitTo == "F") { this.Result = TemperatureService.fromCelToFa(quantity).ToString(); }
            else if (unitFrom == unitTo) { this.Result = quantity.ToString(); }
            else if (unitFrom == "F" && unitTo == "C") { this.Result = TemperatureService.fromFaToCel(quantity).ToString(); }
            else if (unitFrom == "K" && unitTo == "F") { this.Result = TemperatureService.fromKelToFa(quantity).ToString(); }
            else if (unitFrom == "F" && unitTo == "K") { this.Result = TemperatureService.fromFaToKel(quantity).ToString(); }
            else if (unitFrom == "K" && unitTo == "C") { this.Result = TemperatureService.fromKelToCel(quantity).ToString(); }
            else if (unitFrom == "C" && unitTo == "K") { this.Result = TemperatureService.fromCelToKel(quantity).ToString(); }
            else { return null; }

            return result;
        }
    }
}
