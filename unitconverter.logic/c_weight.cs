using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class c_weight : Iconverter
    {
        public string name => "Wagi";
        public List<string> units_names => new List<string>()
        {
            "lb",
            "kg",
            "t"
        };
        public List<decimal> units_values => new List<decimal>()
        {
            1,
            2.204585537918871m,
            1000
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

                    value = value * units_values[i];
                }
            }
            else if (to_index > from_index) // / next convertion lvl
            {
                for (int i = from_index; i < to_index; i++)
                {
                    value = value / units_values[i + 1];
                }
            }
            return value;
        }
    }
}
