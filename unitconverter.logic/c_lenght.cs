using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class c_lenght : Iconverter
    {
        public string name => "Długości";
        public List<string> units_names => new List<string>()
        {
            "m",
            "km",
            "mi"
        };
        public List<decimal> units_values => new List<decimal>()
        {
            1,
            1000,
            1.609344m
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
            int from_index = units_names.FindIndex(x => x==from_name); //return index where name match
            int to_index = units_names.FindIndex(x => x == to_name);
            if(to_index < from_index) // * next convertion lvl
            {
                for (int i = from_index; i > to_index; i--)
                {

                    value = value * units_values[i];    
                }
            }else if (to_index > from_index) // / next convertion lvl
            {
                for (int i = from_index; i < to_index; i++)
                {
                    value = value / units_values[i+1];
                }    
            }
            return value;
        }
    }
}
