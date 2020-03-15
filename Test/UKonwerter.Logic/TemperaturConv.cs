using System;
using System.Collections.Generic;
using System.Text;

namespace UnitCorventer
{
    public class TemperaturConv : IConverter
    {
        public string Name => "Temperaturatury";
        private string from_type;
        private string to_type;
        decimal unit_value;
        public List<string> Units => new List<string>()
        {
            "F",
            "C",
            "K"
        };
        public string From_type
        {
            get => from_type;
            set
            {
                while (value != "C" && value != "F" && value != "K")
                {
                    Console.WriteLine("Podaj poprawną jednostke z: ");
                    value = Console.ReadLine();
                }
                from_type = value;
            }
        }
        public string To_type
        {
            get => to_type;
            set
            {
                while (value != "C" && value != "F" && value != "K")
                {
                    Console.WriteLine("Podaj poprawną jednostke do: ");
                    value = Console.ReadLine();
                }
                to_type = value;
            }
        }
        public void List_unit()
        {
            Console.WriteLine("Jednostki do wyboru");
            for (int i = 0; i < Units.Count; i++)
            {
                Console.WriteLine(Units[i]);
            }
        }
        public void Data_and_convert(string from_type, string to_type, decimal value)
        {
            this.From_type = from_type; this.To_type = to_type; this.unit_value = value;
        }

        public decimal Convert()
        {
            decimal result = 0;
            if (from_type == "C" && to_type == "F")
            {
                result = (unit_value * 1.8m) + 32m;
            }
            if (from_type == "C" && to_type == "K")
            {
                result = 273.15m + unit_value;
            }
            if (from_type == "F" && to_type == "C")
            {
                result = (unit_value - 32m) / 1.8m;
            }
            if (from_type == "F" && to_type == "K")
            {
                result = 273.15m + ((unit_value - 32m) / 1.8m);
            }
            if (from_type == "K" && to_type == "C")
            {
                result = unit_value - 273.15m;
            }
            if (from_type == "K" && to_type == "F")
            {
                result = ((unit_value - 273.15m) * 1.8m) + 32m;
            }
            if (from_type == to_type)
            {
                result = unit_value;
            }
            return result;
        }

    }
}
