using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterWPF
{
    class Baza
    {
        private const int maxPerPage = 20;

        public List<KonwersjeTabela> LadujDane()
        {
            using (Model1 context = new Model1())
            {
                List<KonwersjeTabela> lista = context.KonwersjeTabelas.ToList();
                return lista;
            }
        }

        public void DodajRekord(KonwersjeTabela konwersja)
        {
            using (Model1 context = new Model1())
            {
                context.KonwersjeTabelas.Add(konwersja);
                context.SaveChanges();
            }
        }

        public List<KonwersjeTabela> LadujPofiltrowane(string konwerter, DateTime? from, DateTime? to)
        {
            List<KonwersjeTabela> result = LadujDane();
            if(!konwerter.Equals("Wszystkie"))
            {
                result = result.Where(x => x.nazwa == konwerter).ToList();
            }

            if(from != null)
            {
                result = result.Where(x => x.czas >= from).ToList();
            }

            if(to != null)
            {
                result = result.Where(x => x.czas <= to).ToList();
            }

            return result.Take(maxPerPage).ToList();
        }

        public Dictionary<string,int> TopKonwersje()
        {
            List<KonwersjeTabela> result = LadujDane();
            Dictionary<string, int> policzone = new Dictionary<string, int>();
            foreach(KonwersjeTabela konwersja in result)
            {
                if(!policzone.Keys.ToList().Exists(x => x.Equals(konwersja.nazwa)))
                {
                    policzone.Add(konwersja.nazwa, result.Count(x => x.nazwa == konwersja.nazwa));
                }
            }
            policzone = policzone.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
            return policzone;
        }
    }
}
