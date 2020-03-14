using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class c_capacity : Iconverter
    {
        public string name => "Objętości";
        public List<string> units_names => new List<string>()
        {
            "l",
            "gal",
            "m3"
        };
        public List<decimal> units_values => new List<decimal>()
        {
            1,
            4.545454545454545m,
            220
        };
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
