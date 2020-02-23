using System;

namespace ziecina_zad1
{
    class Program
    {
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
            //Console.WriteLine("Poprawny wybór");
            switch (choiceNbr)
            {
                case "1":
                    // code block
                    break;
                case "2":
                    // code block
                    break;
                case "3":
                    // code block
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Niespodziewnay błąd");
                    break;
            }
        }
        static void Main(string[] args)
        {
            Program.Menu();
        }
    }
}
