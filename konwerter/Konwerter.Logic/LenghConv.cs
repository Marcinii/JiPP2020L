using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public class LenghConv :IConverter
    {
        public string name => "Odległości";
        private string from_type;
        private string to_type;
        decimal unit_value;
        public List<string> Units => new List<string>()
        {
            "Km",
            "Mi",
            "m"
        };
        public string From_type
        {
            get => from_type;
            set
            {
                while (value != "Km" && value != "Mi" && value != "m")
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
                while (value != "Km" && value != "Mi" && value != "m")
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
        public void GiveResult()
        {
            Console.WriteLine(unit_value.ToString() + " " + From_type + " = " + Convert().ToString() + " " + to_type);
        }
        public decimal Convert()
        {
            decimal result = 0;
            if (from_type == "Km" && to_type == "Mi")
            {
                result = unit_value * 0.62137m;
            }
            if (from_type == "Km" && to_type == "m")
            {
                result = unit_value * 1000;
            }
            if (from_type == "Mi" && to_type == "Km")
            {
                result = unit_value / 0.62137m;
            }
            if (from_type == "Mi" && to_type == "m")
            {
                result = (unit_value / 0.62137m) / 1000;
            }
            if (from_type == "m" && to_type == "Km")
            {
                result = unit_value / 1000;
            }
            if (from_type == "m" && to_type == "Mi")
            {
                result = (unit_value / 1000) * 0.62137m;
            }
            if (from_type == to_type)
            {
                result = unit_value;
            }
            return result;
        } 
    }
}

