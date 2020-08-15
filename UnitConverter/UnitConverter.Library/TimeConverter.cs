using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Library
{
    class TimeConverter : IConverter
    {
        public string Name => "Time";
        public List<string> Units => new List<string> { "am", "pm", "24h" };

        public double Convert(double inputValue, string inputUnit)
        {
            if (inputUnit == "am")
            {
                return inputValue * 2;
            }
            else if (inputUnit == "pm")
            {
                return inputValue;
            }
            else if (inputUnit == "24h")
            {
                if (inputValue > 12)
                {
                    return inputValue - 12;
                }
                else
                {
                    return inputValue;
                }
            }
            throw new ArgumentException("Invalid input unit " + inputUnit);
        }
    }
}
