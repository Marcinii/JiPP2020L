using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek
{
    public class operacje_1 : Dzialania
    {
        protected double c, f, km, m, kg, ibs;
        Dzialania operacja = new Dzialania();
        public void C_czy_F()
        {
            // pytanie o sposób przeliczania z jakich jednostek stopni na jakie z Celcjuszy czy z Farenhita?
            // równierz pętla aby można było zrobić kilka przeliczeń

            int cf = 0;
            
           
            while (cf != 3)
            {
                Console.WriteLine();
                Console.WriteLine("Przeliczanie z Celcjusza na Fahrenheite wybierz: '1'");
                Console.WriteLine("Przeliczanie z Farenhite na Celcjusza wybierz: '2'");
                Console.WriteLine("Zakoncz przeliczanie stopni i przejdz do wyboru zadan: '3'");
                Console.WriteLine();
                cf = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (cf)
                {
                    case 1: // z celcjuszy na farenhite
                        Console.WriteLine();
                        Console.WriteLine("Podaj temperature w stopniach Celcjusza: ");
                        // odesłanie do funkcji która tylko liczy
                        c = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine($"Temperatura {c} stopni Celcjusza.");
                        operacja.celcjusz(c);
                        Console.WriteLine();

                        break;

                    case 2: // z farenhite na celcjusze
                        Console.WriteLine();
                        Console.WriteLine("Podaj temperature w stopniach Fahrenheita: ");
                        // odesłanie do funkcji która tylko liczy
                        f = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Temperatura {f} stopni Fahrenheita.");
                        operacja.fahrenheit(f);
                        Console.WriteLine();
                        break;

                    case 3: // zakończ działanie
                      
                        break;

                    default: // powtórz wybór
                        Console.WriteLine();
                        Console.WriteLine("Nie wybrano dzialania!");
                        Console.WriteLine("Sprobuj jeszcze raz.");
                        Console.WriteLine();
                        break;
                }
            }
        }

       public void KM_czy_M()
        {
            // pytanie o sposób przeliczania z jakich jednostek odległości na jakie z kilometrów czy z mil?
            // równierz pętla aby można było zrobić kilka przeliczeń

            int k_m = 0;
            while (k_m != 3)
            {
                Console.WriteLine();
                Console.WriteLine("Przeliczanie z Kilometrow na Mile wybierz: '1'");
                Console.WriteLine("Przeliczanie z Mil na Kilometry wybierz: '2'");
                Console.WriteLine("Zakoncz przeliczanie odleglosci i przejdz do wyboru zadan: '3'");
                Console.WriteLine();
                k_m = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (k_m)
                {
                    case 1: // z KM na M
                        Console.WriteLine();
                        Console.WriteLine("Podaj odleglosc w Kilometrach: ");
                        // odesłanie do funkcji która tylko liczy
                        km = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Odleglosc {km} w Kilometrach.");
                        operacja.kilometry(km);
                        Console.WriteLine();
                        break;

                    case 2: // z M na KM
                        Console.WriteLine();
                        Console.WriteLine("Podaj odleglosc w Milach: ");
                        // odesłanie do funkcji która tylko liczy
                        m = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Odleglosc {m} w Milach.");
                        operacja.mile(m);
                        Console.WriteLine();
                        break;

                    case 3: // zakończ działanie

                        break;

                    default: // powtórz wybór
                        Console.WriteLine();
                        Console.WriteLine("Nie wybrano dzialania!");
                        Console.WriteLine("Sprobuj jeszcze raz.");
                        Console.WriteLine();
                        break;
                }
            }
        }

       public  void KG_czy_LBS()
        {
            // pytanie o sposób przeliczania z jakich jednostek wagi na jakie z Kilogramów czy z Funtów?
            // równierz pętla aby można było zrobić kilka przeliczeń

            int kg_lbs = 0;
            while (kg_lbs != 3)
            {
                Console.WriteLine();
                Console.WriteLine("Przeliczanie z Kilogram na Funt wybierz: '1'");
                Console.WriteLine("Przeliczanie z Funt na Kilogram wybierz: '2'");
                Console.WriteLine("Zakoncz przeliczanie stopni i przejdz do wyboru zadan: '3'");
                Console.WriteLine();
                kg_lbs = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (kg_lbs)
                {
                    case 1: // z kg na lbs
                        Console.WriteLine();
                        Console.WriteLine("Podaj wage w Kilogramach: ");

                        // odesłanie do funkcji która tylko liczy
                        kg = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Waga {kg} w Kilogramach.");
                        operacja.kilogramy(kg);
                        Console.WriteLine();
                        break;

                    case 2: // z lbs na kg
                        Console.WriteLine();
                        Console.WriteLine("Podaj wage w Funtach: ");
                        // odesłanie do funkcji która tylko liczy
                        ibs = double.Parse(Console.ReadLine());
                        Console.WriteLine($"Waga {ibs} w Funtach.");
                        operacja.funty(ibs);
                        Console.WriteLine();
                        break;

                    case 3: // zakończ działanie

                        break;

                    default: // powtórz wybór
                        Console.WriteLine();
                        Console.WriteLine("Nie wybrano dzialania!");
                        Console.WriteLine("Sprobuj jeszcze raz.");
                        Console.WriteLine();
                        break;
                }
            }
        }

    }
}
