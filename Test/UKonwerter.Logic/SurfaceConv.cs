using System;
using System.Collections.Generic;
using System.Text;

namespace UnitCorventer
{
    public class SurfaceConv : IConverter
    {
        public string Name => "Powierzchnia";
        private string from_type;
        private string to_type;
        decimal unit_value;
        public List<string> Units => new List<string>() 
        { 
            "km2",
            "ha"
        };
        public string From_type
        {
            get => from_type;
            set
            {
                while (value != "km2" && value != "ha")
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
                while (value != "km2" && value != "ha" )
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
            if (from_type == to_type)
            {
                result = unit_value;
            }
            return result;
        }
    }
}
