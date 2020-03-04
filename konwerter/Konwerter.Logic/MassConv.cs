using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public class MassConv : IConverter
    {
        public string name => "Masy";
        private string from_type;
        private string to_type;
        decimal unit_value;
        public List<string> Units => new List<string>()
        {
            "Kg - kilogramy",
            "F  - funty",
            "g  - gramy"
        };
        public string From_type
        {
            get => from_type;
            set
            {
                while (value != "Kg" && value != "F" && value != "g")
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
                while (value != "Kg" && value != "F" && value != "g" || value == From_type)
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
            Convert();
        }
        public void Convert()
        {
            decimal result = 0;
            if (from_type == "Kg" && to_type == "F")
            {
                result = unit_value * 2.2046m;
            }
            if (from_type == "Kg" && to_type == "g")
            {
                result = unit_value * 1000;
            }
            if (from_type == "F" && to_type == "Kg")
            {
                result = unit_value/2.2046m;
            }
            if (from_type == "F" && to_type == "g")
            {
                result = (unit_value / 2.2046m) * 1000;
            }
            if (from_type == "g" && to_type == "Kg")
            {
                result = unit_value / 1000;
            }
            if (from_type == "g" && to_type == "F")
            {
                result = (unit_value/1000) * 2.2046m;
            }
            Console.WriteLine(unit_value.ToString() + " " + From_type + " = " + result.ToString() + " " + to_type);
        }
    }
}