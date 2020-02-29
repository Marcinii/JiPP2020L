using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverterLogic.Plugins
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "kg", "f", "g" });
        public int Converter(String InputValue, string UnitFrom, string UnitTo)
        {
            return int.Parse(InputValue) * 2;
        }
    }
}
