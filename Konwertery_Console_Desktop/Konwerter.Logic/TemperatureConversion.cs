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
        private double result;

        public string ConverterName { get => converterName; }

        public double Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public double onConvert(double value, string unitFrom, string unitTo)
        {
            if (unitFrom == "C" && unitTo == "F") { this.Result = TemperatureService.fromCelToFa(value); }
            else if (unitFrom == unitTo) { this.Result = value; }
            else if (unitFrom == "F" && unitTo == "C") { this.Result = TemperatureService.fromFaToCel(value); }
            else if (unitFrom == "K" && unitTo == "F") { this.Result = TemperatureService.fromKelToFa(value); }
            else if (unitFrom == "F" && unitTo == "K") { this.Result = TemperatureService.fromFaToKel(value); }
            else if (unitFrom == "K" && unitTo == "C") { this.Result = TemperatureService.fromKelToCel(value); }
            else if (unitFrom == "C" && unitTo == "K") { this.Result = TemperatureService.fromCelToKel(value); }
            else { return 0; }

            return result;
        }
    }
}
