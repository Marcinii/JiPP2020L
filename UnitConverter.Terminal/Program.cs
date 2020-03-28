using System;
using UnitConverter.Library;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.OperationUtil.Runner;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.Terminal
{

    /// <summary>
    /// Klasa uruchamiająca całą aplikację konsolową
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            UnitOperationRepository repository = new UnitOperationRepository();
            UnitOperationRepositoryInitializer initializer = new UnitOperationRepositoryInitializer(repository);
            initializer.initializeRepository();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("######################################################");
                Console.WriteLine("# Co chcesz skonwertować (wybierz jedną z opcji)?");
                Console.WriteLine("#----------------------------------------------------#");

                repository.operations.ForEach(operation => Console.WriteLine("# {0}. {1}", operation.id, operation.name));

                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine("# 0. Wyjście z programu");
                Console.WriteLine("#----------------------------------------------------#");

                Console.Write("> ");

                AppConsole.readValueTo<CustomInteger>(command =>
                {
                    if (command == 0) Environment.Exit(0);
                    repository.selectOperation(command);
                });

                Console.Clear();

                CommandLineOperationRunner runner = new CommandLineOperationRunner(repository);
                runner.run();

                Console.WriteLine();
                Console.WriteLine("Naciśnij dowolny klawisz, by przejść dalej...");
                _ = Console.ReadKey(true).KeyChar;
            }
        }
    }
}
