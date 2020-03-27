using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterWPF
{
    class Godziny
    {
        private string inputFormat;
        private string outputFormat;
        private string value;
        public const string Hours12Format = "12";
        public const string Hours24Format = "24";

        public Godziny(string inputFormat, string outputFormat)
        {
            this.inputFormat = inputFormat;
            this.outputFormat = outputFormat;
        }

        public void AddInput(string value)
        {
            this.value = value;
        }

        public string GetOutput()
        {
            if(inputFormat == Hours12Format)
            {
                //przykad 9:21 PM -> 21:21
                DateTime dt = DateTime.Parse(value);
                return dt.ToString("HH:mm");
            }
            else if(inputFormat == Hours24Format)
            {
                //przyklad 16:35 -> 8:35 PM
                DateTime dt = DateTime.Parse(value);
                return dt.ToString("h:mm tt");
            }
            else
            {
                return "";
            }
        }

        public DateTime ToDateTime()
        {
            return DateTime.Parse(value);
        }
    }
}
