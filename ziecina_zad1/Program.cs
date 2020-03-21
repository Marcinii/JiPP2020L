using System;

namespace ziecina_zad1
{
    class Program
    {
        /*
        static public void tempe_conv()
        {
            string unit = "";
            Console.WriteLine("Zamiana jednostek temperatury\nPodaj jednostkę (C/F)");
            unit = Console.ReadLine();
            while(!(unit == "C" || unit == "F" || unit == "c" || unit == "f"))
            {
                Console.WriteLine("Niepoprawna jednostka. Podaj jednostkę (C/F)");
                unit = Console.ReadLine();
            }
            if(unit == "c" || unit =="C")
            {
                Console.WriteLine("Podaj ilość stopni C:");
                try
                {
                    float degreeC = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + (1.8 * degreeC + 32) + " stopni Farenheita\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }
                
                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }else if(unit == "f" || unit == "F")
            {
                Console.WriteLine("Podaj ilość stopni F:");
                try
                {
                    float degreeF = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + ((degreeF - 32)/1.8) + " stopni Celcjusza\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }

                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }

        }
        static public void dist_conv()
        {
            string unit = "";
            Console.WriteLine("Zamiana jednostek odległości\nPodaj jednostkę (km/mi)");
            unit = Console.ReadLine();
            while (!(unit == "km" || unit == "mi"))
            {
                Console.WriteLine("Niepoprawna jednostka. Podaj jednostkę (km/mi)");
                unit = Console.ReadLine();
            }
            if (unit == "km")
            {
                Console.WriteLine("Podaj odległość w km:");
                try
                {
                    float degreeC = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + (0.62137 * degreeC) + " mil\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }

                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }
            else if (unit == "mi")
            {
                Console.WriteLine("Podaj odległość w milach:");
                try
                {
                    float degreeF = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + (degreeF/ 0.62137) + " kilometrów\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }

                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }

        }
        static public void mass_conv()
        {
            string unit = "";
            Console.WriteLine("Zamiana jednostek masy\nPodaj jednostkę (kg/lbs)");
            unit = Console.ReadLine();
            while (!(unit == "kg" || unit == "lbs" ))
            {
                Console.WriteLine("Niepoprawna jednostka. Podaj jednostkę (kg/lbs)");
                unit = Console.ReadLine();
            }
            if (unit == "kg")
            {
                Console.WriteLine("Podaj ilość kiogramów");
                try
                {
                    float degreeC = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + (2.20462262 * degreeC) + " funtów\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }

                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }
            else if (unit == "lbs")
            {
                Console.WriteLine("Podaj ilość funtów");
                try
                {
                    float degreeF = float.Parse(Console.ReadLine());
                    Console.WriteLine("To " + (degreeF/ 2.20462262) + " kilogramów\n"); //KONWERSJA
                }
                catch
                {
                    Console.WriteLine("Niepoprawna liczba");
                    tempe_conv();
                    return;
                }

                //tu można dać pytanie czy chce jeszcze raz zamienieć
                Menu();
            }

        }
        static public void Menu()
        {
            string choiceNbr = "";
            bool firstLoop = true;
            while (!(choiceNbr == "1" || choiceNbr == "2" || choiceNbr == "3" || choiceNbr == "4"))
            {
                if (firstLoop == false)
                {
                    Console.WriteLine("Niepoprawny wybór, spróbuj ponownie\n");
                }
                Console.WriteLine("Wybierz konwersję: (1/2/3");
                Console.WriteLine("1: Temperatura - pomiędzy stopniami Celsjusza i Farenheita");
                Console.WriteLine("2: Długość - pomiędzy kilometrami i milami");
                Console.WriteLine("3: Masa - pomiędzy kilogramami i funtami");
                Console.WriteLine("4: Wyjście z programu");
                firstLoop = false;
                choiceNbr = Console.ReadLine();
            }
            //Poprawny wybór
            switch (choiceNbr)
            {
                case "1":
                    tempe_conv();
                    break;
                case "2":
                    dist_conv();
                    break;
                case "3":
                    mass_conv();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niespodziewnay błąd");
                    break;
            }
        }
        */
        static void Main(string[] args)
        {
            //Program.Menu();
            Menu converterMenu = new Menu();
        }
    }
}
