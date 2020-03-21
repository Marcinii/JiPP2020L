using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class WeightConversion : IConverter
    {
        public List<string> units = new List<string> { "ibs", "kg", "g" };
        private string converterName = "Wagi";
        private string result;

        public string ConverterName { get => converterName; }
        public string Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public string onConvert(string value, string unitFrom, string unitTo)
        {
            double quantity = Convert.ToDouble(value);
            if (unitFrom == "ibs" && unitTo == "kg") { this.Result = WeightService.fromIbsToKg(quantity).ToString(); }
            else if (unitFrom == unitTo) { this.Result = quantity.ToString(); }
            else if (unitFrom == "kg" && unitTo == "ibs") { this.Result = WeightService.fromKgToIbs(quantity).ToString(); }
            else if (unitFrom == "kg" && unitTo == "g") { this.Result = WeightService.fromKgToGr(quantity).ToString(); }
            else if (unitFrom == "g" && unitTo == "kg") { this.Result = WeightService.fromGrToKg(quantity).ToString(); }
            else if (unitFrom == "ibs" && unitTo == "g") { this.Result = WeightService.fromIbsToGr(quantity).ToString(); }
            else if (unitFrom == "g" && unitTo == "ibs") { this.Result = WeightService.fromGrToIbs(quantity).ToString(); }
            else { return null; }

            return result;
        }
    }
}
