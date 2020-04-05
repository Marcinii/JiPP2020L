using UnitConverter.App.Util;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.UnitUtil;

namespace UnitConverter.App.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, który reprezentuję funkcję,
    /// która będzie uruchamiana po wykonaniu operacji konwertowania jednostek miar
    /// </summary>
    /// <param name="mainWindowUtils">
    ///     Pole przechowujące referencję do obiektu, które ma za zadanie zarządzać glównym oknem aplikacji
    /// </param>
    /// <see cref="TaskRunFunction"/>
    public class MainWindowConversionAfterRunTaskRunFunction : TaskRunFunction
    {
        private MainWindowUtils mainWindowUtils;

        public MainWindowConversionAfterRunTaskRunFunction(MainWindowUtils mainWindowUtils)
        {
            this.mainWindowUtils = mainWindowUtils;
        }



        public void apply(IRunnable runnable)
        {
            mainWindowUtils.value = (ICustomType)runnable.getResult();
            MainWindow mainWindow = mainWindowUtils.mainWindow;

            SelectableTaskParameterOption selectedToConversionOption = TaskParameterUtils.toSelectableTaskParameter(
                    runnable.getParameter("toConversion")
            ).getSelectedOption();

            Unit toUnit = (Unit)selectedToConversionOption.value;

            if (toUnit.type == typeof(CustomDouble))
            {
                mainWindow.convertedValueLabel.Content = ((CustomDouble)CustomTypeUtils.createInstanceFrom(
                    toUnit.type, runnable.getResult().ToString()
                )).roundTo(mainWindow.commaDigitCountComboBoxUtils.getSelectedContent());
            }
            else
            {
                mainWindow.convertedValueLabel.Content = CustomTypeUtils.createInstanceFrom(
                    toUnit.type, runnable.getResult().ToString()
                ).ToString();
            }
        }
    }
}
