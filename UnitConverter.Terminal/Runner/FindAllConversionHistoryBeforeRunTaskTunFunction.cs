using System;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Terminal.Core;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, reprezentująca nowe zadanie.
    /// Klasa ta jest wywoływana przed uruchomieniem zadania przeszukującego historię konwersji.
    /// Wyświetla w konsoli parametry i oczekuje od użytkownika, że te parametry zostana wprowadzone
    /// </summary>
    public class FindAllConversionHistoryBeforeRunTaskTunFunction : TaskRunFunction
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
                    ICustomType res = AppConsole.readValueTo(((InputTaskParameter)parameter).type, parameter.level == TaskParameterLevel.REQUIRED);
                    parameter.value = res;
                }
            });
        }
    }
}
