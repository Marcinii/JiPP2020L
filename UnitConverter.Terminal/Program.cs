using System;
using UnitConverter.Library;
using UnitConverter.Library.OperationUtil;

namespace UnitConverter.Terminal
{

    class Program
    {

        static void Main(string[] args)
        {
            OperationRepository repository = new OperationRepository();
            OperationRepositoryInitializer.initializeRepository(repository);


            while (true)
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
