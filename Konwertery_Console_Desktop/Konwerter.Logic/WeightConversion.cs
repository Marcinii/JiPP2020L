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
        private double result;

        public string ConverterName { get => converterName; }
        public double Result { set => result = value; }
        public List<string> ConverterUnits { get => units; }

        public double onConvert(double value, string unitFrom, string unitTo)
        {
            if (unitFrom == "ibs" && unitTo == "kg") { this.Result = WeightService.fromIbsToKg(value); }
            else if (unitFrom == unitTo) { this.Result = value; }
            else if (unitFrom == "kg" && unitTo == "ibs") { this.Result = WeightService.fromKgToIbs(value); }
            else if (unitFrom == "kg" && unitTo == "g") { this.Result = WeightService.fromKgToGr(value); }
            else if (unitFrom == "g" && unitTo == "kg") { this.Result = WeightService.fromGrToKg(value); }
            else if (unitFrom == "ibs" && unitTo == "g") { this.Result = WeightService.fromIbsToGr(value); }
            else if (unitFrom == "g" && unitTo == "ibs") { this.Result = WeightService.fromGrToIbs(value); }
            else { return 0; }

            return result;
        }
    }
}
