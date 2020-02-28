using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerterjednostekk
{
    class Program
    {
        public int temp_conventer()
        {
            Console.WriteLine("1 Celsjusz --> Farenheit");
            Console.WriteLine("2 Farenheit --> Celsjusz");
            string liczba = Console.ReadLine();
            switch (liczba)
            {
                case "1":
                    Console.WriteLine("Podaj ilość stopni w celsjusza:");
                    int celsjusz = int.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi temperatura w farenheitach: ");
                    return celsjusz + 32;

                case "2":
                    Console.WriteLine("Podaj ilość stopni farenheita");
                    int farenheita = int.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi temperatura w celsjuszach: ");
                    return farenheita - 32;
            }
            return 0;
        }

        public double length_conventer()
        {
            Console.WriteLine("1 Kilometry --> Mile");
            Console.WriteLine("2 Mile --> Kilometry");
            string liczba = Console.ReadLine();

            switch (liczba)
            {
                case "1":
                    Console.WriteLine("Podaj długość w kilometrach:");
                    double kilometry = double.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi długość w milach: ");
                    return kilometry * 0.62137;

                case "2":
                    Console.WriteLine("Podaj długość w milach:");
                    double mile = double.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi długość w kilometrach:");
                    return mile / 0.62137;
            }
            return 0;

        }

        public double weight_conventer()
        {
            Console.WriteLine("1 Kilogramy --> Funty");
            Console.WriteLine("2 Funty --> Kilogramy");
            string liczba = Console.ReadLine();

            switch (liczba)
            {
                case "1":
                    Console.WriteLine("Podaj mase w kilogramach:");
                    double kilogramy = double.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi masa w funtach:");
                    return kilogramy * 2.2046;
                case "2":
                    Console.WriteLine("Podaj mase w funtach:");
                    double funty = double.Parse(Console.ReadLine());
                    Console.WriteLine("Tyle wynosi masa w kilogramach:");
                    return funty / 2.2046;
            }
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wybierz rodzaj konwersji:");
            Console.WriteLine("1  Konwerter temperatury");
            Console.WriteLine("2  Konwerter długości");
            Console.WriteLine("3  Konwerter masy");
            string kk = Console.ReadLine();
            int temper = 0;
            double dlugo = 0;
            double masa = 0;
            Program konwerter = new Program();

            switch (kk)
            {
                case "1":
                    temper = konwerter.temp_conventer();
                    Console.WriteLine(temper);
                    break;
                case "2":
                    dlugo = konwerter.length_conventer();
                    Console.WriteLine(dlugo);
                    break;
                case "3":
                    masa = konwerter.weight_conventer();
                    Console.WriteLine(masa);
                    break;
            }


            System.Console.ReadKey();
        }
    }
}
