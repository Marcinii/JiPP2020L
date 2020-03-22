using System;
using System.Collections.Generic;
using System.Text;

namespace ZAD2
{
    class Zadanie 
    {
        static void Main(string[] args)
        {
            List<IProgram> converters = new List<IProgram>()
            {
                new Masa(),
                new Odleglosc(),
                new Temperatura(),
                new Objetosc()
            };
            int numer = 0;
            double liczba;
            bool czyBlad = true;

            while (czyBlad) 
            {

                for(int i =0;i<converters.Count;i++)
                {
                    Console.WriteLine("({0}) {1}", i + 1 , converters[i].Name);
                }
                Console.WriteLine("{0} {1} {2}","\nWybierz opcje wpisujac liczbe od 1 do",converters.Count,":");
                numer = int.Parse(Console.ReadLine());

                Console.WriteLine("Podaj jednostke Z:");
                string j_z = Console.ReadLine();

                Console.WriteLine("Podaj jednostke Do:");
                string j_do = Console.ReadLine();

                Console.WriteLine("\nWprowadz dane: ");
                liczba = double.Parse(Console.ReadLine());

                double wynik = converters[numer - 1].Konwersja(j_z, j_do, liczba);
                Console.WriteLine("\nWynik: {0}{1}",wynik,j_do);
                czyBlad = true;
                          
            }
        }
    }
}

