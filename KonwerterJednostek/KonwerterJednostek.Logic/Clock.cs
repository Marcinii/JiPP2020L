using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJednostek.Logic
{
    public class Clock : IConverter
    {
        public string value;
        public double hValue;
        public double h24;
        public double h12;

        public Clock()
        {
            this.value = "";
            this.h24 = 0;
            this.h12 = 0;
        }
        public Clock(string value)
        {
            if (value.Length >= 5)
            {
                this.value = value;
                bool succes = double.TryParse(value.Substring(0, 2), out double hValue);
                if (succes) { this.hValue = hValue; }
                else { this.hValue = 0; }
                this.h24 = Option1();
                this.h12 = Option2();
            }
            else
            {
                this.value = "";
                this.h24 = 0;
                this.h12 = 0;
            }
        }

        public string Name => "Zegar";

        public List<string> Units => new List<string>()
        {
            "24-hours",
            "12-hours"
        };

        public void Info()
        {
            throw new NotImplementedException();
        }

        public double Option1()
        {
            return this.hValue + 12;
        }

        public double Option2()
        {
            return this.hValue - 12;
        }

        public void UnitConv()
        {
            throw new NotImplementedException();
        }

        public string UnitConv(string from, string to, string number)
        {
            Clock t = new Clock(number);
            if(number.Length!=5 || number.Substring(2,1)!=":" ||
                !int.TryParse(number.Substring(0,1), out int test0) || !int.TryParse(number.Substring(1,1), out int test1) ||
                !int.TryParse(number.Substring(3,1), out int test2) || !int.TryParse(number.Substring(4,1), out int test3) ||
                test0 < 0 || (test0 == 2 && test1 > 4) || test0 > 2 || test2 < 0 || test2 > 5)
            {
                return Error.Info();
            }
            else
            {
                int.TryParse(number.Substring(0, 2), out int h);
                string rest = number.Substring(2, 3);
                if(h>0 && h < 12)
                {
                    string first = h < 10 ? "0" + h : h.ToString();
                    return first + rest + "AM";
                }
                else if (h > 12 && h != 24)
                {
                    return t.h12 >= 10 ? t.h12 + rest + "PM" : "0" + t.h12 + rest + "PM";
                }
                else if (h == 12)
                {
                    return t.value + "PM";
                }
                else if (h == 24 || h == 0)
                {
                    return "00" + rest + "AM";
                }
                else { return Error.Info(); }
            }
        }
    }
}
