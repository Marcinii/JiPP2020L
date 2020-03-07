using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jedn
{
    class Program
    {
        static void Main()
        {
            int wybor = 0;
            Konwerter nowy = new Konwerter();
            Console.WriteLine("To konwerter jednostek. Wybierz operacje.");
            Console.WriteLine("Jednostki temperatury:");
            Console.WriteLine("1. Zamiana stopni Celsjusza na stopnie Fahrenheita;");
            Console.WriteLine("2. Zamiana stopni Fahrenheita na stopnie Celsjusza;");
            Console.WriteLine("Jednostki odleglosci:");
            Console.WriteLine("3. Zamiana kilometrow na mile;");
            Console.WriteLine("4. Zamiana mil na kilometry;");
            Console.WriteLine("Jednostki masy:");
            Console.WriteLine("5. Zamiana kilogramow na funty;");
            Console.WriteLine("6. Zamiana funtow na kilogramy;");
            wybor = Convert.ToInt32(Console.ReadLine());
            switch(wybor)
            {
                case 1:
                    nowy.CtoF();
                    break;
                case 2:
                    nowy.FtoC();
                    break;
                case 3:
                    nowy.KmtoM();
                    break;
                case 4:
                    nowy.MtoKm();
                    break;
                case 5:
                    nowy.KgtoF();
                    break;
                case 6:
                    nowy.FtoKg();
                    break;


            }
            Console.ReadLine();
        }
    }
}
