﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class u_zlecenie : Iumowy
    {   
        public string name => "Zlecenie";

        public decimal count_brutto_netto(string value, bool is_26)
        {
            decimal value_brutto = parse.convert_string_to_decimal(value);
            decimal value_netto = (value_brutto / 100) * 91;
            return value_netto;
        }

        public decimal count_netto_brutto(string value, bool is_26)
        {
            decimal value_netto = parse.convert_string_to_decimal(value);
            decimal value_brutto = (value_netto / 91) * 100;
            return value_brutto;
        }

        public decimal show_percent(bool is_26)
        {
            return 91;
        }
    }
}