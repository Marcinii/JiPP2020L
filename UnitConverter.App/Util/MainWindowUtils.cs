using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UnitConverter.App.Util
{
    /// <summary>
    /// Klasa, która wykonuje podstawowe operacje na kontrolkach w oknie <see cref="MainWindow"/>
    /// </summary>
    class MainWindowUtils
    {
        private MainWindow mainWindow;
        private DoubleUtils doubleUtils;

        public MainWindowUtils(MainWindow mainWindow, DoubleUtils doubleUtils)
        {
            this.mainWindow = mainWindow;
            this.doubleUtils = doubleUtils;
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

            mainWindow.convertedValueGrid.Visibility = Visibility.Hidden;

            mainWindow.formatNumberCheckBox.IsEnabled = false;
            mainWindow.formatNumberLabel.Cursor = Cursors.Arrow;
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

                double res = doubleUtils.roundTo(mainWindow.operation.convert(
                    Convert.ToDouble(mainWindow.providedValueTextBox.Text.Replace(".", ",")),
                    mainWindow.fromUnit,
                    mainWindow.toUnit
                ), (int)selectedItem.Content);

                mainWindow.convertedValueLabel.Content = ((bool) this.mainWindow.formatNumberCheckBox.IsChecked)
                    ? this.doubleUtils.toFormattedNumber(res)
                    : Convert.ToString(res);
            }
        }
    }
}
