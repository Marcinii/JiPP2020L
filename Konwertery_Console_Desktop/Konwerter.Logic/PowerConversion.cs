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
        private double result;

        public string ConverterName { get => converterName; }

        public double Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public double onConvert(double value, string unitFrom, string unitTo)
        {
            if (unitFrom == "W" && unitTo == "KM") { this.Result = PowerService.fromWatToKm(value); }
            else if (unitFrom == unitTo) { this.Result = value; }
            else if (unitFrom == "KM" && unitTo == "W") { this.Result = PowerService.fromKmToWat(value); }
            else { return 0; }

            return result;
        }
    }
}
