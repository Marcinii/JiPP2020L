using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UnitConverter.UnitUtil;

namespace UnitConverterApp.Util
{
    /// <summary>
    /// Klasa, która wykonuje podstawowe operacje na kontrolkach w oknie <see cref="MainWindow"/>
    /// </summary>
    class MainWindowUtils
    {
        private MainWindow mainWindow;

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

            mainWindow.fromUnit = null;
            mainWindow.toUnit = null;

            mainWindow.swapButton.IsEnabled = false;

            mainWindow.commaDigitCountComboBox.IsEnabled = false;
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
                ComboBoxItem selectedItem = (ComboBoxItem)mainWindow.commaDigitCountComboBox.SelectedItem;

                mainWindow.convertedValueLabel.Content = DoubleUtils.roundTo(mainWindow.operation.convert(
                    Convert.ToDouble(mainWindow.providedValueTextBox.Text.Replace(".", ",")),
                    mainWindow.fromUnit,
                    mainWindow.toUnit
                ), (int)selectedItem.Content);
            }
        }
    }
}
