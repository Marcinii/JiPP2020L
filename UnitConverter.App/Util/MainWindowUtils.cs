using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnitConverter.Library.Converter;
using UnitConverter.Library.TypeUtil;

namespace UnitConverter.App.Util
{
    /// <summary>
    /// Klasa, która wykonuje podstawowe operacje na kontrolkach w oknie <see cref="MainWindow"/>
    /// </summary>
    class MainWindowUtils
    {
        public MainWindow mainWindow { get; private set; }
        public ICustomType value { get; private set; }

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

            mainWindow.operationRepository.resetOperation();

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
                ComboBoxItem selectedItem = (ComboBoxItem)mainWindow.commaDigitCountComboBox.SelectedItem;
                string input = mainWindow.providedValueTextBox.Text;

                if (mainWindow.operationRepository.getSelectedOperation().getFromUnit().type == typeof(Custom12HTime))
                {
                    if(mainWindow.providedValueTextBoxUtils.valid && !Regex.IsMatch(mainWindow.providedValueTextBox.Text, @"\s([Aa]|[Pp])[Mm]$"))
                    {
                        ComboBoxItem comboBoxItem = (ComboBoxItem) this.mainWindow.timeFormatComboBox.SelectedItem;
                        Custom12HTimeType timeType =  (Custom12HTimeType) comboBoxItem.Content;
                        input += " " + timeType.ToString();
                    }
                }

                DefaultConverter converter = new DefaultConverter(
                    CustomTypeUtils.createInstanceFrom(
                        mainWindow.operationRepository.getSelectedOperation().getFromUnit().type,
                        input
                    ),
                    mainWindow.operationRepository.getSelectedOperation().getFromUnit(),
                    mainWindow.operationRepository.getSelectedOperation().getToUnit()
                );



                this.value = converter.convert();

                if(mainWindow.operationRepository.getSelectedOperation().getToUnit().type == typeof(CustomDouble))
                {
                    mainWindow.convertedValueLabel.Content = ((CustomDouble)CustomTypeUtils.createInstanceFrom(
                        mainWindow.operationRepository.getSelectedOperation().getToUnit().type,
                        this.value
                    )).roundTo((int)selectedItem.Content);
                }
                else
                {
                    mainWindow.convertedValueLabel.Content = CustomTypeUtils.createInstanceFrom(
                        mainWindow.operationRepository.getSelectedOperation().getToUnit().type,
                        this.value
                    ).ToString();
                }
            }
        }
    }
}
