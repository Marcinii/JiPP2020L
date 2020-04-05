using System;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Terminal.Core;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, który reprezentuje funkcję wywołująca się
    /// przed właściwym wykonaniem zadania. Metoda ta wyświtla i wymaga od użytkownika wprowadzenia
    /// wszystkich wymaganych parametrów danego zadania.
    /// </summary>
    public class ConversionOperationBeforeRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            runnable.getParameters().forEachRequired(parameter =>
            {
                if (TaskParameterUtils.isSelectableTaskParameter(parameter))
                {
                    SelectableTaskParameter selectableTaskParameter = (SelectableTaskParameter)parameter;

                    Console.WriteLine("######################################################");
                    Console.WriteLine("# {0} (wybierz jedną z opcji)?", selectableTaskParameter.label);
                    Console.WriteLine("#----------------------------------------------------#");
                    selectableTaskParameter.options.ForEach(option =>
                    {
                        Console.WriteLine("# {0}. {1}", option.id, option.name);
                    });
                    Console.WriteLine("#----------------------------------------------------#");
                    Console.Write("> ");
                    selectableTaskParameter.selectOption(AppConsole.readCustomInteger());
                }
                else
                {
                    Console.Write("# Wprowadź parametr ({0}): ", parameter.name);
                    SelectableTaskParameter fromConversion = (SelectableTaskParameter)runnable.getParameter("fromConversion");
                    parameter.value = AppConsole.readValueTo(fromConversion.getSelectedOption().type);
                }
            });
        }
    }
}
