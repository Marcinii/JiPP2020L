using System;
using UnitConverter.App;
using UnitConverter.Core;

namespace UnitConverter
{

    class Program
    {

        static void Main(string[] args)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("######################################################");
                Console.WriteLine("# Co chcesz skonwertować (wybierz jedną z opcji)?");
                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine("# 1. Konwersja temperatury");
                Console.WriteLine("# 2. Konwersja długości");
                Console.WriteLine("# 3. Konwersja masy");
                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine("# 0. Wyjście z programu");

                Console.Write("> ");
                int command = AppConsole.readInt();

                while (command < 0 || command > 3)
                {
                    Console.WriteLine("!!! Nie rozpoznano komendy. Wprowadź poprawny numer komendy");
                    Console.Write("> ");
                    command = AppConsole.readInt();
                }

                Console.Clear();

                ConverterWizard wizard = new ConverterWizard();
                WizardResult res;
                Converter converter;


                switch (command)
                {
                    case 1:
                        wizard.addUnitName("stopnie Celsjusza", "stopnie Fahrenheitt'a");
                        res = wizard.run();

                        converter = new TemperatureConverter(res.value, res.convertTo);
                        converter.print();
                        break;

                    case 2:
                        wizard.addUnitName("kilometry", "metry");
                        res = wizard.run();

                        converter = new DistanceConverter(res.value, res.convertTo);
                        converter.print();
                        break;

                    case 3:
                        wizard.addUnitName("kilogramy", "funty");
                        res = wizard.run();

                        converter = new WeightConverter(res.value, res.convertTo);
                        converter.print();
                        break;

                    case 0: Environment.Exit(0); break;
                }

                Console.WriteLine();
                Console.WriteLine("Naciśnij dowolny klawisz, by przejść dalej...");
                _ = Console.ReadKey(true).KeyChar;
            }
        }
    }
}
