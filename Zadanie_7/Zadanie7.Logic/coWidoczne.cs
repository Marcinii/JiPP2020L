using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie7.Logic
{
    public class coWidoczne
    {
        public string coPokazac(string v1,string v2)
        {
            if (v1 == "obwód")
            {
                if(v2 == "Zadanie_7.trojkat")
                {
                    return "1";
                }else if(v2 == "Zadanie_7.kwadrat")
                {
                    return "2";
                }
                else
                {
                    return "0";
                }
            }
            else if (v1 == "pole")
            {
                if(v2 == "Zadanie_7.trojkat")
                {
                    return "3";
                }else if (v2 == "Zadanie_7.kwadrat")
                {
                    return "4";
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }
    }
}
