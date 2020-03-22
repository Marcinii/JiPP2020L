using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unitconverter.logic
{
    public class c_time : Iconverter 
    //ciąg liczby gdzie kazda oznacza inna rzecz (dane wejsciowe z formularza):
    //12 - z jakiego systemu, przyjmuje wartosc 12 lub 24
    //04 - godzina z
    //15 - minuta z 
    //2 - am czy pm, przyjmuje wartosc 1 (am) 2 (pm) lub 0 (jesli z 24 godzinnnego)  
    //dane wyjsciowe do wyswietlenia wyniku
    //24 - z jakiego systemu, przyjmuje wartosc 12 lub 24
    //16 - godzina do
    //15 - minuta do
    //0 - am czy pm, przyjmuje wartosc 1 (am) 2 (pm) lub 0 (jesli z 24 godzinnnego)  
    {
        public string name => "czas";
        public List<string> units_names => new List<string>()
        {
            "12",
            "24"
        };
        public List<decimal> units_values => new List<decimal>()
        {
            1,
            12
        };
        private decimal to_24(decimal hour, decimal am_pm)
        {
            if(am_pm == 2)
            {
                hour += 12;
            }
            return hour;
        }
        private decimal[] to_12(decimal hour)
        {
            decimal am_pm = 0;
            if(hour > 12)
            {
                hour -= 12;
                am_pm = 2;
            }
            else
            {
                am_pm = 1;
            }
            decimal[] hours = new decimal[] { hour, am_pm };
            return hours;
        }
        public decimal custom_convert(string[] data_array)
        {
            string value = data_array[0];
            string from = data_array[1];
            string hour_and_minute = value;
            string ampm = "0";
            if (value.Length == 7 || value.Length == 6)
            {
                char am_pm = value[value.Length - 2]; 
                if(value.Length == 7)
                {
                    hour_and_minute = value.Remove(5, 2);
                }else if (value.Length == 6)
                {
                    hour_and_minute = value.Remove(4, 2);
                }
                if (am_pm.Equals('a'))
                {
                    ampm = "1";
                }
                else if(am_pm.Equals('p'))
                {
                    ampm = "2";
                }
            }
            string[] time = hour_and_minute.Split(':');
            string string_time = from + time[0] + time[1] + ampm;
            decimal return_time = parse.convert_string_to_decimal(string_time);
            return return_time;
        }
        public string custom_result_interpreter(decimal decimal_time)
        {
            int time = parse.convert_decimal_to_int(decimal_time); //separate numbers to make operations on them
            int from_system = time / 100000;
            int hour = (time / 1000) - (from_system * 100);
            int minute = (time / 10) - (from_system * 10000 + hour * 100);
            int am_pm = time - (from_system * 100000 + hour * 1000 + minute * 10);
            string string_hour = hour.ToString();
            string string_minute = minute.ToString();
            string string_am_pm = "";
            if(am_pm == 1)
            {
                string_am_pm = "am";
            }
            else if (am_pm == 2)
            {
                string_am_pm = "pm";
            }
            string string_result = string_hour + ":" + string_minute + string_am_pm;
            return string_result;
        }
        public decimal operation(string from_name, string to_name, decimal value)
        {
            int int_value = parse.convert_decimal_to_int(value); //separate numbers to make operations on them
            int from_system = int_value / 100000; 
            int hour = (int_value / 1000) - (from_system * 100); 
            int minute = (int_value / 10) - (from_system * 10000 + hour * 100); 
            int am_pm = int_value - (from_system * 100000 + hour * 1000 + minute * 10); 
            bool is_data_ok = false; //start validate data
            if(am_pm == 1 || am_pm == 2)
            {
                if(hour >= 0 && hour < 13)
                {
                    is_data_ok = true;
                }
            }else if(am_pm == 0)
            {
                if (hour >= 0 && hour < 24)
                {
                    is_data_ok = true;
                }
            }
            if (minute >= 0 && minute < 60)
            {
                is_data_ok = true;
            }
            else
            {
                is_data_ok = false;
            }
            //end validate data
            if (is_data_ok)
            {
                decimal return_converted = 0;
                decimal[] converted_tab;
                decimal converted = 0;
                if (from_system == 12)
                {
                    converted = to_24(hour, am_pm);
                    return_converted = (24 * 100000 + converted * 1000 + minute * 10 + 0);
                }else if(from_system == 24)
                {
                    converted_tab = to_12(hour);
                    return_converted = (12 * 100000 + converted_tab[0] * 1000 + minute * 10 + converted_tab[1]);
                }
                return return_converted;
            }
            else
            {
                return 0;
            }  
        }
    }
}
