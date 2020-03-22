using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{ 
    public interface Iconverter
    {
        string name { get; } //converter name
        //both tables should be from smallest to biggest
        List<string> units_names { get; } //list with unit names
        List<decimal> units_values { get; } //list with unit values 
        decimal operation(string from_name, string to_name, decimal value); //this function choose operation and return value
        decimal custom_convert(string[] data_array); //array custam data for special convertion
        string custom_result_interpreter(decimal result); 

    }
}
