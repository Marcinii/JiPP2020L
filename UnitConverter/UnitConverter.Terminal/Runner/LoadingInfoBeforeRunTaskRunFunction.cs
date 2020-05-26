using System;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, reprezentująca nowe zadanie.
    /// Klasa ta jest wywoływana przed uruchomieniem zadania przeszukującego historię konwersji.
    /// Wyświetla w konsoli napis informujący użytkownika o ładowaniu się danych
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class LoadingInfoBeforeRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            Console.Clear();
            Console.WriteLine("Ładowanie...");
        }
    }
}
