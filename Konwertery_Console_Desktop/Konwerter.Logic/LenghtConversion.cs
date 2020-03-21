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
        private string result;

        public string Result { set => result = value; }

        public string ConverterName { get => converterName; }

        public List<string> ConverterUnits { get => units; }

        public string onConvert(string value, string unitFrom, string unitTo)
        {
            double quantity = Convert.ToDouble(value);
            if (unitFrom == "km" && unitTo == "mile") { this.Result = LenghtService.fromKmToMiles(quantity).ToString(); }
            else if (unitFrom == unitTo) { this.Result = quantity.ToString(); }
            else if (unitFrom == "mile" && unitTo == "km") { this.Result = LenghtService.fromKmToMiles(quantity).ToString(); }
            else if (unitFrom == "cm" && unitTo == "km") { this.Result = LenghtService.fromCmToKm(quantity).ToString(); }
            else if (unitFrom == "km" && unitTo == "cm") { this.Result = LenghtService.fromKmToCm(quantity).ToString(); }
            else if (unitFrom == "cm" && unitTo == "mile") { this.Result = LenghtService.fromCmToMiles(quantity).ToString(); }
            else if (unitFrom == "mile" && unitTo == "cm") { this.Result = LenghtService.fromMilesToCm(quantity).ToString(); }
            else{ return null; }

            return result;
        }
    }
}
