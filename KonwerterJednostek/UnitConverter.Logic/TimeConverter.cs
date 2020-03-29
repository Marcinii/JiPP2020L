using KonwerterJednostek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    public class TimeConverter : IConverter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>
        {
            "12",
            "24"
        };

        public double Convert(int from, int to, double valueToConvert)
        {
            double correctMinuteValues = checkCorrectnessOfMinuteValue(valueToConvert);
            decimal correctTime = (decimal)checkCorrectnessOfHourValue(correctMinuteValues);
            //list all of available units and their conversion values
            decimal[][] factor =
                {
                    new decimal[] {correctTime, correctTime + 12}, //12
                    new decimal[] {correctTime<12?correctTime:correctTime-12, correctTime}, //24
                };
            decimal result = factor[from][to];
            decimal correctTimeAfterCheck = (decimal)checkCorrectnessOfHourValue((double)result);
            return (double)correctTimeAfterCheck;
        }

        private double checkCorrectnessOfMinuteValue(double valueToCheck) {
            int hourVariable = (int)valueToCheck;
            decimal minuteVariable = (decimal)valueToCheck - hourVariable;
            decimal correctTimeFormat = minuteVariable >= 0.6M ?
                hourVariable + 1 + (decimal.Subtract(minuteVariable,0.6M)) : (decimal)valueToCheck;
            return (double)correctTimeFormat;
        }

        private double checkCorrectnessOfHourValue(double valueToCheck)
        {
            int hourVariable = (int)valueToCheck;            
            if (hourVariable >= 24)
            {
                decimal minuteVariable = (decimal)valueToCheck - hourVariable;
                int modulo = hourVariable % 24;
                return modulo + (double)minuteVariable;
            }
            else {
                return valueToCheck;
            }           
        }


    }
}
