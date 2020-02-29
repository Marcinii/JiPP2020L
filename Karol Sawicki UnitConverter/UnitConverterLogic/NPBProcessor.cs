using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace UnitConverterLogic
{
    public class NPBProcessor
    {
        public string Testnbp()
        {


            //Send HTTP requests from here.  
            string url = @"http://api.nbp.pl/api/exchangerates/tables/a/last/5/";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (rate != null)
                    {
                        return (rate.Mid);
                    }
                    else return "Null";
                }
                else return "Null";
            }

        }


        public class TableObject
        {
            public string Table { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public RateObject[] Rates { get; set; }
        }

        public class RateObject
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public string Mid { get; set; }
            public string Test { get; set; }

        }




    }
}


