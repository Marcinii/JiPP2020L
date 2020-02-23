using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    /*Celsjusze na Fahrenheity*/
    class CF
    {
        double C;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja Skala Celsjusza -> Skala Fahrenheita");
            do
            {
                Console.Write("Podaj temperature do konwersji w stopniach Celsjusza: ");
                C = Convert.ToDouble(Console.ReadLine());
            } while (C <= -274);
        }
        public double tempCF()
        {
            return 32.0 + 9.0 / 5.0 * C;
        }
        public void info()
        {
            Console.WriteLine("\nTemperatura " + C.ToString() + " st. C = " + Math.Round(tempCF(), 2).ToString() + " st. F");
        }
    }

    /*Fahrenheity na Celsjusze*/
    class FC
    {
        double F;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja Skala Fahrenheita -> Skala Celsjusza");
            do
            {
                Console.Write("Podaj temperature do konwersji w stopniach Fahrenheita: ");
                F = Convert.ToDouble(Console.ReadLine());
            } while (F <= -460);
        }
        public double tempFC()
        {
            return 5.0 / 9.0 * (F - 32.0);
        }
        public void info()
        {
            Console.WriteLine("\nTemperatura " + F.ToString() + " st. F = " + Math.Round(tempFC(), 2).ToString() + " st. C");
        }
    }

    /*Kilometry na Mile LADOWE*/
    class KM
    {
        double K;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja kilometry -> mile ladowe");
            do
            {
                Console.Write("Podaj dlugość do konwersji w kilometrach: ");
                K = Convert.ToDouble(Console.ReadLine());
            } while (K < 0);
        }
        public double dlKM()
        {
            return K / 1.609344; /*1 mila ladowa = 1,609344 km; 1 mila morskia = 1,85166 km*/
        }
        public void info()
        {
            Console.WriteLine("\nDlugosc " + K.ToString() + " km = " + Math.Round(dlKM(), 2).ToString() + " mil ladowych");
        }
    }

    /*Mile LADOWE na Kilometry*/
    class MK
    {
        double M;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja mile ladowe -> kilometry");
            do
            {
                Console.Write("Podaj dlugość do konwersji w milach: ");
                M = Convert.ToDouble(Console.ReadLine());
            } while (M < 0);
        }
        public double dlMK()
        {
            return M * 1.609344; /*1 mila ladowa = 1,609344 km; 1 mila morskia = 1,85166 km*/
        }
        public void info()
        {
            Console.WriteLine("\nDlugosc " + M.ToString() + " mil ladowych = " + Math.Round(dlMK(), 2).ToString() + " km");
        }
    }

    /*kilogramy na funty*/
    class KF
    {
        double K;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja kilogramow -> funty");
            do
            {
                Console.Write("Podaj mase do konwersji w kilogramach: ");
                K = Convert.ToDouble(Console.ReadLine());
            } while (K < 0);
        }
        public double masaKF()
        {
            return K * 2.20462;
        }
        public void info()
        {
            Console.WriteLine("\nMasa " + K.ToString() + " kg = " + Math.Round(masaKF(), 2).ToString() + " funtow");
        }
    }

    /*funty na kilogramy*/
    class FK
    {
        double F;
        public void pobierz_dane()
        {
            Console.WriteLine("Konwersja funtow -> kilogramy");
            do
            {
                Console.Write("Podaj mase do konwersji w funtach: ");
                F = Convert.ToDouble(Console.ReadLine());
            } while (F < 0);
        }
        public double masaFK()
        {
            return F / 2.20462;
        }
        public void info()
        {
            Console.WriteLine("\nMasa " + F.ToString() + " funtow = " + Math.Round(masaFK(), 2).ToString() + " kg");
        }
    }
}
