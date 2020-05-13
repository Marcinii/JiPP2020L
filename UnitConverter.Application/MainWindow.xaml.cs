using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil.TypeException;
using System;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Library.TaskUtil.Parameter;
using UnitConverter.Library.UnitUtil;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Application.AppWindow;
using UnitConverter.Application.Util;
using UnitConverter.Application.Command;

namespace UnitConverter.Application
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowUtils mainWindowUtils;
        private StatusBarUtils statusBarUtils;
        private GroupBoxUtils groupBoxUtils;

        private ListBoxUtils<SelectableTaskParameterOption> fromUnitListBoxUtils;
        private ListBoxUtils<SelectableTaskParameterOption> toUnitListBoxUtils;

        private CheckBoxUtils formatNumberCheckBoxUtils;

        private OperationRepository operationRepository;

        public Operation selectedOperation { get; private set; }

        public ComboBoxUtils<Operation> measurementUnitComboBoxUtils { get; private set; }
        public ComboBoxUtils<int> commaDigitCountComboBoxUtils { get; private set; }
        public ComboBoxUtils<Custom12HTimeType> timeFormatComboBoxUtils { get; private set; }

        public TextBoxUtils providedValueTextBoxUtils { get; private set; }



        public MainWindow()
        {
            InitializeComponent();

            this.operationRepository = ((App)System.Windows.Application.Current).repository;

            this.mainWindowUtils = new MainWindowUtils(this);
            this.statusBarUtils = new StatusBarUtils(this.helperTextStatusBar);
            this.groupBoxUtils = new GroupBoxUtils();

            this.groupBoxUtils.addGroupBox(typeof(CustomDouble), this.customDoubleAdditionalOptionsComboBox);
            this.groupBoxUtils.addGroupBox(typeof(Custom12HTime), this.customTimeAdditionalOptionsGroupBox);

            this.measurementUnitComboBoxUtils = new ComboBoxUtils<Operation>((ComboBox)this.measurementUnitComboBox.content);
            this.commaDigitCountComboBoxUtils = new ComboBoxUtils<int>((ComboBox)this.commaDigitCountComboBox.content);
            this.timeFormatComboBoxUtils = new ComboBoxUtils<Custom12HTimeType>((ComboBox)this.timeFormatComboBox.content);

            this.fromUnitListBoxUtils = new ListBoxUtils<SelectableTaskParameterOption>(this.fromUnitListBox);
            this.toUnitListBoxUtils = new ListBoxUtils<SelectableTaskParameterOption>(this.toUnitListBox);

            this.providedValueTextBoxUtils = new TextBoxUtils((TextBox)this.providedValueTextBox.content);

            this.formatNumberCheckBoxUtils = new CheckBoxUtils((CheckBox)this.formatNumberCheckBox.content);

            this.statusBarUtils.addStatusBarText(this.measurementUnitComboBox, "Wprowadż wartość do skonwertowania");
            this.statusBarUtils.addStatusBarText(this.providedValueTextBox, "Wprowadź wartość do przekonwertowania");
            this.statusBarUtils.addStatusBarText(this.fromUnitListBox, "Wybierz jednostkę, z której chcesz skonwertować liczbę");
            this.statusBarUtils.addStatusBarText(this.toUnitListBox, "Wybierz jednostkę, na którą chcesz skonwertować liczbę");
            this.statusBarUtils.addStatusBarText(this.swapButton, "Zamień jednosti miejscami");
            this.statusBarUtils.addStatusBarText(this.commaDigitCountComboBox, "Wybierz liczbę widocznych cyfer po przecinku");
            this.statusBarUtils.addStatusBarText(this.formatNumberCheckBox, "Dzieli liczbę przed przecinkiem co 3 cyfry, by liczba była czytelniejsza");
            this.statusBarUtils.addStatusBarText(this.timeFormatComboBox, "Ustala, czy wprowadzona godzina jest przed południem (AM) lub po południu (PM)");

            this.mainWindowUtils.resetForm();

            measurementUnitComboBoxUtils.initialize(
                ((SelectableTask)this.operationRepository.findOperationById(1).task).getOperations()
            );

            commaDigitCountComboBoxUtils.initialize(Enumerable.Range(0,8).ToList());
            timeFormatComboBoxUtils.initialize(Enum.GetValues(typeof(Custom12HTimeType)).Cast<Custom12HTimeType>().ToList());

            this.operationRepository.selectOperation(1);
            this.selectedOperation = this.operationRepository.getSelectedOperation();

            this.swapButton.Command = new ButtonCommand(
                x => swap(), 
                x => this.toUnitListBox.SelectedItem != null
            );
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego wybranego elementu z listy <see cref="measurementUnitComboBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void measurementUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainWindowUtils.resetForm();

            this.fromUnitListBox.IsEnabled = true;

            SelectableTask currentTask = (SelectableTask)this.selectedOperation.task;

            currentTask.selectOperation(this.measurementUnitComboBoxUtils.getSelectedContent().id);

            Operation currentSelectedOperation = currentTask.getSelectedOperation();

            SelectableTaskParameter fromConversion = (SelectableTaskParameter) currentSelectedOperation.task.getParameter("fromConversion");
            SelectableTaskParameter toConversion = (SelectableTaskParameter) currentSelectedOperation.task.getParameter("toConversion");

            fromUnitListBoxUtils.initialize(fromConversion.options);
            toUnitListBoxUtils.initialize(toConversion.options);

            this.groupBoxUtils.hideGroupBoxes();
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego 
        /// wybranego elementu z listy <see cref="fromUnitListBox"/> (lista oznaczona etykietką 'Z czego chcesz skonwertować')
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromUnitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.fromUnitListBox.SelectedIndex < 0)
                return;

            SelectableTask currentTask = (SelectableTask)this.selectedOperation.task;
            SelectableTaskParameter fromConversion = (SelectableTaskParameter)currentTask.getSelectedOperation().task.getParameter("fromConversion");

            fromConversion.selectOption(this.fromUnitListBoxUtils.getSelectedContent().id);

            if (fromConversion.isOptionSelected())
            {
                this.providedValueTextBox.IsEnabled = true;
                this.toUnitListBox.IsEnabled = true;

                try
                {
                    this.mainWindowUtils.updateConvertedLabel();
                }
                catch (CustomTypeException)
                {
                    this.providedValueTextBoxUtils.clear();
                }
            }
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego wybranego elementu z listy <see cref="toUnitListBox"/> (lista oznaczona etykietką 'Na co chcesz skonwertować')
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toUnitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.toUnitListBox.SelectedIndex < 0)
                return;

            SelectableTask currentTask = (SelectableTask)this.selectedOperation.task;
            SelectableTaskParameter toConversion = (SelectableTaskParameter)currentTask.getSelectedOperation().task.getParameter("toConversion");

            toConversion.selectOption(this.toUnitListBoxUtils.getSelectedContent().id);

            if (toConversion.isOptionSelected())
            {
                this.providedValueTextBox.IsEnabled = true;

                this.mainWindowUtils.updateConvertedLabel();

                SelectableTaskParameter fromConversion = (SelectableTaskParameter)currentTask.getSelectedOperation().task.getParameter("fromConversion");
                Unit fromUnit = (Unit)fromConversion.getSelectedOption().value;

                this.groupBoxUtils.activateGroupBoxByType(fromUnit.type);

                if (fromUnit.type == typeof(Custom12HTime))
                {
                    this.clock.show();
                }
                else
                {
                    this.clock.hide();
                }
            }
        }




        /// <summary>
        /// Metoda wywołująca się, gdy pole tekstowe "Wartość początkowa" <see cref="providedValueTextBox"/> zmieni swoją wartość.
        /// W trakcie zmiany wartości pola tekstowego, wartość ta jest od razu konwertowana z jednostki wybranej w polu <see cref="fromUnitListBox" /> na jednostkę <see cref="toUnitListBox"/>
        /// Metoda ta waliduje również wprowadzaną wartość. Akceptuje tylko liczby zmiennoprzecinkowe. Dozwolone są także liczby ujemne
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void providedValueTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectableTask currentTask = (SelectableTask)this.selectedOperation.task;
            SelectableTaskParameter fromConversion = (SelectableTaskParameter)currentTask.getSelectedOperation().task.getParameter("fromConversion");
            Unit fromUnit = (Unit)fromConversion.getSelectedOption().value;

            try
            {
                if (this.providedValueTextBoxUtils.isNullOrEmpty())
                {
                    this.convertedValueLabel.Content = "0";
                    this.convertedValueGrid.Visibility = Visibility.Hidden;
                    this.clock.setTime("00:00");
                }
                else
                {
                    this.convertedValueGrid.Visibility = Visibility.Visible;
                    this.mainWindowUtils.updateConvertedLabel();
                }

                this.providedValueTextBoxUtils.setToValid();
                this.formatNumberCheckBox.disabled = this.providedValueTextBoxUtils.isNullOrEmpty();
                this.formatNumberCheckBox.IsEnabled = !this.providedValueTextBoxUtils.isNullOrEmpty();
                this.commaDigitCountComboBox.IsEnabled = !this.providedValueTextBoxUtils.isNullOrEmpty();
            }
            catch (CustomTypeIncorrectValueException)
            {
                this.providedValueTextBoxUtils.setToInvalid();
                this.formatNumberCheckBox.IsEnabled = false;
            }

            this.timeFormatComboBox.disabled = Regex.IsMatch(this.providedValueTextBoxUtils.getText(), @"\s([Aa]|[Pp])[Mm]$")
                                                        || !providedValueTextBoxUtils.valid
                                                        || providedValueTextBoxUtils.isNullOrEmpty();

            if (!this.timeFormatComboBox.disabled)
                this.clock.setTime(this.providedValueTextBoxUtils.getText() + " " + this.timeFormatComboBoxUtils.getSelectedContent().ToString());
        }




        /// <summary>
        /// Metoda ma za zadanie zamianę miejscami jednoski w listach <see cref="fromUnitListBox"/> i <see cref="toUnitListBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swap()
        {
            int temp = this.fromUnitListBox.SelectedIndex;
            this.fromUnitListBox.SelectedIndex = this.toUnitListBox.SelectedIndex;
            this.toUnitListBox.SelectedIndex = temp;
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy przemieszczamy się myszką po knie aplikacji.
        /// Ma ona za zadanie wykrywanie elementu, nad którym obecnie znajduje się kursor.
        /// Jeśli aktualnie najechany element znajduje się w liście {statusBarMessages} w klasie <see cref="StatusBarUtils"/>,
        /// wówczas wartość statusu <see cref="helperTextStatusBar"/> zmienia się w zależności od najechanego elementu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Source is Control)
            {
                this.statusBarUtils.setStatusBarText((Control)e.Source);
            }
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy dojdzie do zmiany aktualnie zaznaczonego elementu w liście rozwijanej <see cref="commaDigitCountComboBox"/>
        /// Metoda ta od razu konwertuje liczbę tylko wtedy, gdy pole tekstowe <see cref="providedValueTextBox" /> jest aktywne (tylko wtedy ma wprowadzoną wartość)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commaDigitCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.commaDigitCountComboBox.IsEnabled)
            {
                this.convertedValueLabel.Content = ((CustomDouble)this.mainWindowUtils.value).roundTo(this.commaDigitCountComboBoxUtils.getSelectedContent());
            }
        }




        /// <summary>
        /// Metoda, która jest wykonywana w momencie, gdy klikniemy na etykietę <see cref="formatNumberLabel"/>
        /// Metoda ta odpowiedzialna jest za zmianę stany chckbox'a <see cref="formatNumberCheckBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatNumberLabel_MouseLeftButtonUp(object sender, EventArgs e)
        {
            if (this.formatNumberCheckBoxUtils.isEnabled())
                this.formatNumberCheckBoxUtils.toggle();
        }




        /// <summary>
        /// Metoda wywołująca się w momencie gdy stan checkbox'a <see cref="formatNumberCheckBox"/> się zmieni.
        /// Metoda ta zmienia sposób wyświetlania skonwertowanej liczby w aplikacji na podstawie stanu checkbox'a.
        /// Jeżeli checkbox jest aktywny, wówczas formatowanie jest aplikowane. Jesli nie, wówczas liczba jest wyświetlana normalnie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatNumberCheckBox_Change(object sender, RoutedEventArgs e)
        {
            this.convertedValueLabel.Content = formatNumberCheckBoxUtils.isChecked()
                                            ? ((CustomDouble)this.mainWindowUtils.value).toFormattedString()
                                            : this.mainWindowUtils.value.ToString();
        }




        /// <summary>
        /// Metoda, która wywołuje się w momencie, gdy klikniemy na opcję "Kopiuj wynik" w menu kontekstowym.
        /// To menu kontekstowe można wyświetlić, klikając prawym przyciskiem myszy na wynik konwersji.
        /// Metoda ta ma za zadanie wstawienie wartości skonwertowanej liczby do schowka. Dzięki czemu można wykorzystać skonwertowaną wartość.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToClipBoardMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(
                Regex.Replace(this.convertedValueLabel.Content.ToString(), @"\s", "")
            );
        }




        /// <summary>
        /// Metoda, która wywołuje się w momencie, gdy dojdzie do zmiany aktualnie zaznaczonego elementu w liście rozwijanej <see cref="timeFormatComboBox"/>
        /// Lista rozwijana pojawia się w momencie, gdy chcemy konwertować godzinę 12-godzinną na 24-godzinną.
        /// Lista jest widoczna wtedy, gdy format godziny wprowadzony <see cref="providedValueTextBox"/> jest prawidłowy, 
        /// oraz gdy wartość tegoż pola tekstowego nie kończy się na "AM" lub "PM".
        /// Po wybraniu opcji w liście rozwijanej wprowadzona godzina jest aktualizowana przez dodanie sufiksu o wartości wybranego elementu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeFormatComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => mainWindowUtils.updateConvertedLabel();



        /// <summary>
        /// Metoda, która jest uruchamiana w momecie, gdy zostanie kliknięty element górnego menu <see cref="closeApplicationMenuItem"/>.
        /// Ma ona za zadanie zakończenie działania uruchomionej aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeApplicationMenuItem_Click(object sender, RoutedEventArgs e) => Environment.Exit(0);



        /// <summary>
        /// Metoda, która wywołuje się w momencie kliknięcia na element <see cref="displayStatisticsMenuItem"/>.
        /// Metoda ta otwiera okno statystyk wykonanych konwersji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayStatisticsMenuItem_Click(object sender, RoutedEventArgs e) => new StatisticsWindow().Show();



        /// <summary>
        /// Metoda wywołująca się w momencie kliknięcia elementu menu <see cref="displayApplicationInfoMenuItem"/>.
        /// Metoda ta otwiera okienko, które wyświetla podstawowe informacje o autorze projektu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayApplicationInfoMenuItem_Click(object sender, RoutedEventArgs e) => new ApplicationInfoWindow().Show();



        /// <summary>
        /// Metoda wywołująca się w momencie kliknięcia elementu menu <see cref="displayRatingWindowMenuItem"/>.
        /// Metoda ta otwiera okienko wyświetlające widżet do ocenienia aplikacji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayRatingWindowMenuItem_Click(object sender, RoutedEventArgs e) => new RatingInfoWindow().Show();
    }
}
