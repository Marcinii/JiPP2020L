using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitConverter_M2
{
    public class LengthConv : IConv
    {
        // w celu zmniejszenia liczby instrukcji w convert()
        // normalizuję "from" do metrów, a nastepnie zamieniam na "to"
        // w tym celu muszę przyporządkować do każdej używanej jednostki
        // jej wartośc w metrach - zrobię to przy pomocy słownika

        Dictionary<string, decimal> meterNormalize = new Dictionary<string, decimal>()
        {
            { "m", 1 },
            { "km", 1000 },
            { "mi", 1609}
        };

        public string operationName => "Dlugosc";

        public List<string> units => new List<string>() {"m","km","mi"};

        public decimal convert(string from, string to, decimal valueToConvert)
        {
            // normalizuj from do metrów (zamien na metry jakakolwiek to by nie byla jednostka
            decimal inMetersValue = meterNormalize.FirstOrDefault(t => t.Key == from).Value;
            valueToConvert *= inMetersValue;

            // zamien z metrow na dowolna inna jednostke
            return valueToConvert / meterNormalize.FirstOrDefault(t => t.Key == to).Value;
        }

        // zwraca nazwe typu konwersji
        public override string ToString()
        {
            return operationName;
        }
    }
}
