using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace logic
{
    public class u_oprace : Iumowy
    {
        public string name => "O pracę";

        public decimal count_brutto_netto(string value, bool is_26)
        {
            decimal value_brutto = parse.convert_string_to_decimal(value);
            decimal value_netto = (value_brutto / 100) * 71.4m;
            if (!is_26)
            {
                value_netto += (value_brutto / 100) * 7.12m;
            }
            return value_netto;
        }

        public decimal count_netto_brutto(string value, bool is_26)
        {
            decimal value_netto = parse.convert_string_to_decimal(value);
            decimal value_brutto;
            if (is_26)
            {
                value_brutto = (value_netto / 71.4m) * 100;
            }
            else
            {
                value_brutto = (value_netto / 78.52m) * 100;
            }  
            return value_brutto;
        }

        public decimal show_percent(bool is_26)
        {
            decimal to_return = 0;
            if (is_26)
            {
                to_return = 71.4m;
            }
            else
            {
                to_return = 78.52m;
            }
            return to_return;
        }
    }
}
