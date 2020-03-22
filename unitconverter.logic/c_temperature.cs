using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class c_temperature : Iconverter
    {
        public string name => "Temperatury";
        public List<string> units_names => new List<string>()
        {
            "c",
            "f",
            "k"
        };
        public List<decimal> units_values => new List<decimal>()
        {
            1,
            32,
            459.67m
        };
        public decimal custom_convert(string[] data_array)
        {
            return 0;
        }
        public string custom_result_interpreter(decimal result)
        {
            return "0";
        }
        public decimal operation(string from_name, string to_name, decimal value)
        {
            int from_index = units_names.FindIndex(x => x == from_name); //return index where name match
            int to_index = units_names.FindIndex(x => x == to_name);
            if (to_index < from_index) // * next convertion lvl
            {
                for (int i = from_index; i > to_index; i--)
                {
                    if(i == 2)
                    {
                        value = (value * 1.8m) - units_values[i];
                    }else if (i == 1)
                    {
                        value = (value - units_values[i]) /1.8m;
                    }
                }
            }
            else if (to_index > from_index) // / next convertion lvl
            {
                for (int i = from_index; i < to_index; i++)
                {
                    if (i == 0)
                    {
                        value = (value * 1.8m) + units_values[i + 1];
                    }
                    else if (i == 1)
                    {
                        value = (value + units_values[i + 1]) * 5 / 9;
                    }
                }
            }
            return value;
        }
    }
}

