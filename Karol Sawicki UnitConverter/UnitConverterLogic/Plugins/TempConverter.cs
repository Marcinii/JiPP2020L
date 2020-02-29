using System;
using System.Collections.Generic;

namespace UnitConverterLogic.Plugins
{
    public class TempConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "C", "K", "F" });
        public int Converter(String InputValue, string UnitFrom, string UnitTo)
        {
            return int.Parse(InputValue) + 273;
        }
    }
}
