using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ziecinaUnitConverter.Logic
{
    public class ConvertHour
    {
        public string Convert(string startHour, string format)
        {
            string endHour = "k"; //edit
            DateTime d;
            try
            {
                switch (format)
                {
                    case "AM":
                        d = DateTime.Parse(startHour + " " + format);
                        endHour = d.ToString("HH:mm");
                        break;
                    case "PM":
                        d = DateTime.Parse(startHour + " " + format);
                        endHour = d.ToString("HH:mm");
                        break;
                    case "24h":
                        d = DateTime.Parse(startHour);
                        endHour = d.ToString("h:mm tt");
                        break;
                }
            }
            catch(Exception)
            {
                endHour = "Niepoprawny format daty";
            }
            return  endHour;
        }
    }
}
