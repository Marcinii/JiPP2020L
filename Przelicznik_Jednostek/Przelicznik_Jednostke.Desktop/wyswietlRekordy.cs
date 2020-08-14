using Przelicznik_Jednostek.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostke.Desktop
{
    public class wyswietlRekordy
    {

        public string stat()
        {
            using(model_danych context = new model_danych())
            {
                List<daneBazaDBO> baza = context.bazaDane.ToList();
                return baza.ToString();
            }
            
        }
}
      /*  public testc<daneBazaDBO>dane { get; set; }

        public wyswietlRekordy()
        {
            model_danych md = new model_danych();
            dane = new testc<daneBazaDBO>(md.bazaDane());
        }*/
      
    
}
