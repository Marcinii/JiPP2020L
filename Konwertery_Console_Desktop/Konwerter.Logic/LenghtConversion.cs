using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LenghtConversion : IConverter
    {
        public List<string> units = new List<string>{ "km", "mile", "cm"};
        private string converterName = "Odległości";
        private double result;

        public double Result { set => result = value; }

        public string ConverterName { get => converterName; }

        public List<string> ConverterUnits { get => units; }

        public double onConvert(double value, string unitFrom, string unitTo)
        {
            if (unitFrom == "km" && unitTo == "mile") { this.Result = LenghtService.fromKmToMiles(value); }
            else if (unitFrom == unitTo) { this.Result = value; }
            else if (unitFrom == "mile" && unitTo == "km") { this.Result = LenghtService.fromKmToMiles(value); }
            else if (unitFrom == "cm" && unitTo == "km") { this.Result = LenghtService.fromCmToKm(value); }
            else if (unitFrom == "km" && unitTo == "cm") { this.Result = LenghtService.fromKmToCm(value); }
            else if (unitFrom == "cm" && unitTo == "mile") { this.Result = LenghtService.fromCmToMiles(value); }
            else if (unitFrom == "mile" && unitTo == "cm") { this.Result = LenghtService.fromMilesToCm(value); }
            else{ return 0; }

            return result;
        }
    }
}
