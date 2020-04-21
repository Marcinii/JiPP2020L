using System;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, która reprezentuje nowe zadanie.
    /// Wywoływana jest po dokonaniu zapisu oceny użytkownika do bazy. Wyswietla w konsoli napis z podziękowaniem za ocenę
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class RatingAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            Console.Clear();
            Console.WriteLine("#-----------------------------------------------------------------#");
            Console.WriteLine("# Dziękuję za ocenienie aplikacji :)");
            Console.WriteLine("#-----------------------------------------------------------------#");

            Console.WriteLine();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wyjść...");
            Console.ReadKey();
        }
    }
}
