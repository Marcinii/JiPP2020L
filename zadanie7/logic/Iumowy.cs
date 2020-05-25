using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public interface Iumowy
    {
        //interface base on % from 10000k 
        string name { get; }
        decimal count_brutto_netto(string value, bool is_26);
        decimal count_netto_brutto(string value, bool is_26);
        decimal show_percent(bool is_26);
    }
}
