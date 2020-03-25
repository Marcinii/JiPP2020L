using System;
using System.Collections.Generic;

namespace KonwerterJednostek
{
    class Program
    {
        static void Zapytanie(string wybor)
        {
            if (wybor == "T" || wybor == "t")
                Main(null);
        }
        static void Main(string[] args)
        {
                //Tworzę listę składającą się z jednostek umieszczonych w odpowiednich klasach
            List<IKonwerter> konwertery = new List<IKonwerter>()
            {
                new KonwerterTemperatura(),
                new KonwerterDlugosc(),
                new KonwerterMas(),
                new KonwerterLitry()
            };


                //Wyświetlam nazwy możliwych mechanizmów konwersji do wyboru
            for(int i=0; i< konwertery.Count;i++)
            {
                Console.WriteLine("({0}) {1}", i + 1, konwertery[i].Nazwa);
            };



                //Użytkownik jest proszony o wybór
            int pickle = 0;
            pickle = Convert.ToInt32(Console.ReadLine());

            if (pickle < 1 || pickle > 6)
            {
                Console.WriteLine("Niepoprawny wybor. Naciśnij ENTER i uruchom program ponownie: ");
                Console.Read();
                System.Environment.Exit(1);
            }

            Console.WriteLine("Podaj jednostkę konwertowaną: ");
            string jednZ = Console.ReadLine();


            Console.WriteLine("Podaj jednostę na którą ma być przekonwertowana poprzednia: ");
            string jednDo = Console.ReadLine();



            double temp;
            //string czyPowtorzyc;

            Console.WriteLine("Wpisz wartość:");
            temp = Convert.ToDouble(Console.ReadLine());

            double wynik = konwertery[pickle - 1].Konwertuj(jednZ, jednDo, temp);
            Console.WriteLine("Wynik po konwersji {0}", wynik);
        }
    }
}
