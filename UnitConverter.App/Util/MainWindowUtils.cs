using System.Windows;
using System.Windows.Input;
using UnitConverter.App.Runner;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.App.Util
{
    /// <summary>
    /// Klasa, która wykonuje podstawowe operacje na kontrolkach w oknie <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowUtils
    {
        public MainWindow mainWindow { get; private set; }
        public ICustomType value { get; set; }

        public MainWindowUtils(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }


        /// <summary>
        /// Metoda, która wyłącza pola w aplikacji tak, aby nie dało się ich zmieniać.
        /// </summary>
        /// <see cref="MainWindow"/>
        public void resetForm()
        {
            mainWindow.providedValueTextBox.IsEnabled = false;
            mainWindow.providedValueTextBox.Text = "";

            mainWindow.fromUnitListBox.IsEnabled = false;
            mainWindow.toUnitListBox.IsEnabled = false;

            mainWindow.swapButton.IsEnabled = false;

            mainWindow.commaDigitCountComboBox.IsEnabled = false;

            mainWindow.convertedValueGrid.Visibility = Visibility.Hidden;

            mainWindow.formatNumberCheckBox.IsEnabled = false;
            mainWindow.formatNumberLabel.Cursor = Cursors.Arrow;

            mainWindow.customTimeFormatSelectionGrid.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Metoda konwertująca wprowadzoną wartość w polu tekstowym {providedValueTextBox} z jednostki wybranej w liście {fromUnitListBox} na jednostkę z listy {toUnitListBox}.
        /// Wartości aktualnie wybranych jednostek są przechowywane odpowiednio w polach {fromUnit} i {toUnit}
        /// </summary>
        /// <see cref="MainWindow"/>
        public void updateConvertedLabel()
        {
            if(mainWindow.providedValueTextBox.Text != "")
            {
                SelectableTask currentTask = (SelectableTask)mainWindow.operationRepository.getSelectedOperation().task;

                currentTask.getSelectedOperation().beforeRun(new MainWindowConversionBeforeRunTaskRunFunction(mainWindow));
                currentTask.getSelectedOperation().afterRun(new MainWindowConversionAfterRunTaskRunFunction(this));

                currentTask.getSelectedOperation().run();
            }
        }
    }
}
