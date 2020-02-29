using System;
using System.Collections.Generic;

namespace UnitConverterLogic.Plugins
{
    public class LenghtConverter : IConverter
    {
        public string Name => "Długość";

        public List<string> Units => new List<string>(new[] { "km", "m", "cal" });

        public int Converter(String InputValue, string UnitFrom, string UnitTo)
        {
            return int.Parse(InputValue) * 1000;
        }
    }
}
