using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KalkulatorCenPosiadlosci.Logika
{
    public static class SpisMiejscowosci
    {
        public static List<Miejscowosc> Miejscowosci = new List<Miejscowosc>
        {
            new Miejscowosc { nazwa = "Warszawa", mnoznikCeny = 105 },
            new Miejscowosc { nazwa = "Gdańsk", mnoznikCeny = 98 },
            new Miejscowosc { nazwa = "Gniezno", mnoznikCeny = 65 },
            new Miejscowosc { nazwa = "Radom", mnoznikCeny = 77 },
            new Miejscowosc { nazwa = "Ząbki", mnoznikCeny = 105 },
        };


        public static void ZaladujBazeDanych() 
        {
          //  using (MiejscowosciBazaDanychEntities context = new MiejscowosciBazaDanychEntities())
              // {
                 //Miejscowosci = context.Miejscowosci.ToList();


              // }

        }


    }
}
