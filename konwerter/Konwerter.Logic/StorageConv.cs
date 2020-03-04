using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public class StorageConv :IConverter
    {
        public string name => "Pojemność Danych";
        private string from_type;
        private string to_type;
        decimal unit_value;
        public List<string> Units => new List<string>()
        {
            "Kb - Kilobajty",
            "Mb - Megabajty",
            "Gb - Gigabajty"
        };
        public string From_type
        {
            get => from_type;
            set
            {
                while (value != "Kb" && value != "Mb" && value != "Gb")
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
                while (value != "Kb" && value != "Mb" && value != "Gb" || value == From_type)
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
            if (from_type == "Kb" && to_type == "Mb")
            {
                result = unit_value / 1024m;
            }
            if (from_type == "Kb" && to_type == "Gb")
            {
                result = (unit_value / 1024m) / 1024m;
            }
            if (from_type == "Mb" && to_type == "Kb")
            {
                result = unit_value * 1024m;
            }
            if (from_type == "Mb" && to_type == "Gb")
            {
                result = unit_value / 1024m;
            }
            if (from_type == "Gb" && to_type == "Mb")
            {
                result = unit_value * 1024m;
            }
            if (from_type == "Gb" && to_type == "Kb")
            {
                result = (unit_value * 1024m) * 1024m;
            }
            return result;
        }
    }
}
