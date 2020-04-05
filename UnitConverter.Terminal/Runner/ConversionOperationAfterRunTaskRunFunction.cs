using System;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil.Void;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, który reprezentuje funkcję wywołująca się
    /// po właściwym wykonaniu zadania. Klasa ta wyświetla wynik konwersji jednostek miar w konsoli
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class ConversionOperationAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            if (runnable.getResult().GetType() != typeof(CustomVoid))
            {
                Console.WriteLine();
                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine(
                    "# ({0}): {1} => ({2}): {3}", 
                    ((SelectableTaskParameter)runnable.getParameter("fromConversion")).getSelectedOption().name,
                    runnable.getParameter("value").value,
                    ((SelectableTaskParameter)runnable.getParameter("toConversion")).getSelectedOption().name,
                    runnable.getResult()
                );
                Console.WriteLine("#----------------------------------------------------#");
                Console.WriteLine();
                Console.WriteLine("Wciśnij dowolny klawisz, aby kontynuować...");
                Console.ReadKey();
            }
        }
    }
}
