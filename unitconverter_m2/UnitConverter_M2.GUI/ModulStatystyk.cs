using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UnitConverter_M2.GUI
{

    class ModulStatystyk
    {
        int strona = 0;
        DataGrid tabelaDanych;
        List<logi> logi_aplikacji;

        /* filtry */
        DateTime? d1 = null;
        DateTime? d2 = null;
        string typ = null;
        bool top3;

        public ModulStatystyk(DataGrid tabelaDanych)
        {
            this.tabelaDanych = tabelaDanych;
            this.strona = 0;

            wyswietl();
        }

        public void wyswietl()
        {
            using (konwersjeEntities context = new konwersjeEntities())
            {
                logi_aplikacji = context.logi
                    /* filtruj typ jesli nie jest nullem */
                    .Where(e => typ == null || e.rodzaj == typ)
                    /* filtruj daty jesli nie sa nullami */
                    .Where(e => d1 == null || e.data >= d1)
                    .Where(e => d2 == null || e.data <= d2)
                    .OrderBy(e => e.data)
                    .Skip(20*this.strona)
                    .Take(20)
                    .ToList();

                if (top3)
                {
                    /* jesli ma byc top3 kategorii */
                    var top3logi = logi_aplikacji
                        .GroupBy(e => e.rodzaj)
                        .Select(gr => new { Rodzaj = gr.Key, Total = gr.Count() })
                        .OrderByDescending(e => e.Total)
                        .Take(3);

                    tabelaDanych.ItemsSource = top3logi;
                }
                else
                {
                    tabelaDanych.ItemsSource = logi_aplikacji;
                }

            }
        }

        public void wPrawo()
        {
            this.strona++;
            wyswietl();
        }
        public void wLewo()
        {
            if (strona == 0)
            {
                wyswietl();
                return;
            }
            this.strona--;
            wyswietl();
        }

        public void setStronaZero()
        {
            this.strona = 0;
        }


        public void ustawOd(DateTime d1)
        {
            this.d1 = d1;
        }

        public void ustawDo(DateTime d2)
        {
            this.d2 = d2;
        }



        public void ustawFiltrTypu(string typ)
        {
            this.typ = typ;
        }

        public void wyczyscFiltry()
        {
            this.d1 = null;
            this.d2 = null;
            this.typ = null;
            this.top3 = false;
        }

        public void wylTop3()
        {
            this.top3 = false;
        }
        
        public void wlTop3()
        {
            this.top3 = true;
        }

    }

    
}
