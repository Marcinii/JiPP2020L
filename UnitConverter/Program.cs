using System;
using UnitConverter.Core;
using UnitConverter.UnitUtil;

namespace UnitConverter
{

    class Program
    {

        static void Main(string[] args)
        {

            OperationRepository repository = new OperationRepository();
            Operation temperatures = new Operation(1, "Konwersja temperatury");
            Operation distances = new Operation(2, "Konwersja długości");
            Operation weights = new Operation(3, "Konwersja masy");
            Operation velocities = new Operation(4, "Konwersja objętości");


            temperatures.addUnit(new BaseUnit("stopnie Celsjusza"));
            temperatures.addUnit(
                new Unit("stopnie Fahrenheitt'a",
                         value => 9 * value / 5 + 32,
                         value => 5 * (value - 32) / 9
                )
            );
            temperatures.addUnit(
                new Unit("stopnie Kelvina", value => value + 273.15, value => value - 273.15)
            );
            repository.addOperation(temperatures);




            distances.addUnit(new BaseUnit("metry"));
            distances.addUnit(new Unit("kilometry", value => value / 1000, value => value * 1000));
            distances.addUnit(new Unit("mile", value => value / 1609.344, value => value * 1609.344));
            repository.addOperation(distances);


            weights.addUnit(new BaseUnit("gramy"));
            weights.addUnit(new Unit("kilogramy", value => value / 1000, value => value * 1000));
            weights.addUnit(new Unit("funty", value => value * 0.00220462262, value => value / 0.00220462262));
            repository.addOperation(weights);



            velocities.addUnit(new BaseUnit("litry"));
            velocities.addUnit(
                new Unit("metry sześcienne", value => value / 1000, value => value * 1000)
            );
            velocities.addUnit(
                new Unit("galony", value => value / 3.78541178, value => value * 3.78541178)
            );
            repository.addOperation(velocities);





            while(true)
            {
                Console.Clear();
                Console.WriteLine("######################################################");
                Console.WriteLine("# Co chcesz skonwertować (wybierz jedną z opcji)?");
                Console.WriteLine("#----------------------------------------------------#");

                repository.print();

                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine("# 0. Wyjście z programu");
                Console.WriteLine("#----------------------------------------------------#");

                Console.Write("> ");
                int command = AppConsole.readInt();

                while (command < 0 || command > repository.operations.Count)
                {
                    Console.WriteLine("!!! Nie rozpoznano komendy. Wprowadź poprawny numer komendy");
                    Console.Write("> ");
                    command = AppConsole.readInt();
                }

                if (command == 0) Environment.Exit(0);

                Console.Clear();

                repository.operations[command - 1].run();

                Console.WriteLine();
                Console.WriteLine("Naciśnij dowolny klawisz, by przejść dalej...");
                _ = Console.ReadKey(true).KeyChar;
            }
        }
    }
}
