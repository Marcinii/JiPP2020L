using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnitConverter.App.Util;
using UnitConverterApp.Util;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil.TypeException;
using UnitConverter.Library.TypeUtil;
using System;

namespace UnitConverter.App
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowUtils mainWindowUtils;
        private StatusBarUtils statusBarUtils;
        private GroupBoxUtils groupBoxUtils;

        private ComboBoxUtils<string> measurementUnitComboBoxUtils;
        private ComboBoxUtils<int> commaDigitCountComboBoxUtils;
        private ComboBoxUtils<Custom12HTimeType> timeFormatComboBoxUtils;

        private ListBoxUtils<string> fromUnitListBoxUtils;
        private ListBoxUtils<string> toUnitListBoxUtils;

        public UnitOperationRepository operationRepository { get; private set; }
        public TextBoxUtils providedValueTextBoxUtils { get; private set; }



        public MainWindow()
        {
            InitializeComponent();

            this.operationRepository = new UnitOperationRepository();
            this.mainWindowUtils = new MainWindowUtils(this);
            this.statusBarUtils = new StatusBarUtils(this.helperTextStatusBar);
            this.groupBoxUtils = new GroupBoxUtils();

            this.groupBoxUtils.addGroupBox(typeof(CustomDouble), this.customDoubleAdditionalOptionsComboBox);
            this.groupBoxUtils.addGroupBox(typeof(Custom12HTime), this.customTimeAdditionalOptionsGroupBox);

            UnitOperationRepositoryInitializer initializer = new UnitOperationRepositoryInitializer(this.operationRepository);
            initializer.initializeRepository();

            this.measurementUnitComboBoxUtils = new ComboBoxUtils<string>(this.measurementUnitComboBox);
            this.commaDigitCountComboBoxUtils = new ComboBoxUtils<int>(this.commaDigitCountComboBox);
            this.timeFormatComboBoxUtils = new ComboBoxUtils<Custom12HTimeType>(this.timeFormatComboBox);

            this.fromUnitListBoxUtils = new ListBoxUtils<string>(this.fromUnitListBox);
            this.toUnitListBoxUtils = new ListBoxUtils<string>(this.toUnitListBox);

            this.providedValueTextBoxUtils = new TextBoxUtils(this.providedValueTextBox);

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
                this.operationRepository.operations.Select(item => item.name).ToList()
            );

            commaDigitCountComboBoxUtils.initialize(Enumerable.Range(0,8).ToList());
            timeFormatComboBoxUtils.initialize(Enum.GetValues(typeof(Custom12HTimeType)).Cast<Custom12HTimeType>().ToList());

            this.commaDigitCountComboBox.SelectedIndex = 3;
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego wybranego elementu z listy <see cref="measurementUnitComboBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void measurementUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainWindowUtils.resetForm();

            this.operationRepository.selectOperation(this.measurementUnitComboBox.SelectedIndex + 1);

            this.fromUnitListBox.IsEnabled = true;

            fromUnitListBoxUtils.initialize(this.operationRepository.getSelectedOperation().units.Select(item => item.name).ToList());
            toUnitListBoxUtils.initialize(this.operationRepository.getSelectedOperation().units.Select(item => item.name).ToList());

            this.groupBoxUtils.activateGroupBoxByType(this.operationRepository.getSelectedOperation().type);
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego wybranego elementu z listy <see cref="fromUnitListBox"/> (lista oznaczona etykietką 'Z czego chcesz skonwertować')
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromUnitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.fromUnitListBox.SelectedIndex < 0)
                return;

            this.operationRepository.getSelectedOperation().selectFromUnit(this.fromUnitListBox.SelectedIndex);
            if (this.operationRepository.getSelectedOperation().isFromUnitSelected())
            {
                this.providedValueTextBox.IsEnabled = true;
                this.toUnitListBox.IsEnabled = true;

                try
                {
                    this.mainWindowUtils.updateConvertedLabel();
                }
                catch (CustomTypeException)
                {
                    this.providedValueTextBox.Clear();
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

            this.operationRepository.getSelectedOperation().selectToUnit(this.toUnitListBox.SelectedIndex);
            if (this.operationRepository.getSelectedOperation().isToUnitSelected())
            {
                this.providedValueTextBox.IsEnabled = true;
                this.swapButton.IsEnabled = true;

                this.mainWindowUtils.updateConvertedLabel();

                this.groupBoxUtils.activateGroupBoxByType(this.operationRepository.getSelectedOperation().getFromUnit().type);
                if(this.operationRepository.getSelectedOperation().getFromUnit().type == typeof(Custom12HTime))
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
            string value = this.providedValueTextBox.Text;

            try
            {
                if(value == null || value == "")
                {
                    this.convertedValueLabel.Content = "0";
                    this.formatNumberLabel.Cursor = Cursors.Arrow;
                    this.convertedValueGrid.Visibility = Visibility.Hidden;
                    this.clock.setTime("00:00");
                }
                else
                {
                    this.convertedValueGrid.Visibility = Visibility.Visible;
                    this.formatNumberLabel.Cursor = Cursors.Hand;
                    this.mainWindowUtils.updateConvertedLabel();
                }

                this.providedValueTextBoxUtils.setToValid();
                this.formatNumberCheckBox.IsEnabled = value != null && value != "";
                this.commaDigitCountComboBox.IsEnabled = value != null && value != "";
            }
            catch (CustomTypeIncorrectValueException)
            {
                this.providedValueTextBoxUtils.setToInvalid();
                this.formatNumberCheckBox.IsEnabled = false;
                this.formatNumberLabel.Cursor = Cursors.Arrow;
            }

            this.customTimeFormatSelectionGrid.Visibility = !Regex.IsMatch(this.providedValueTextBox.Text, @"\s([Aa]|[Pp])[Mm]$")
                                                        && providedValueTextBoxUtils.valid
                                                        && providedValueTextBox.Text != ""
                                                     ? Visibility.Visible : Visibility.Collapsed;

            if(this.customTimeFormatSelectionGrid.IsVisible)
                this.clock.setTime(this.providedValueTextBox.Text + " " + this.timeFormatComboBoxUtils.getSelectedContent().ToString());
        }




        /// <summary>
        /// Metoda wywołująca się w momencie, gdy przycisk <see cref="swapButton"/> zostanie kliknięty.
        /// Ma ona za zadanie zamianę miejscami jednoski w listach <see cref="fromUnitListBox"/> i <see cref="toUnitListBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swapButton_Click(object sender, RoutedEventArgs e)
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
        private void formatNumberLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(this.formatNumberCheckBox.IsEnabled)
                this.formatNumberCheckBox.IsChecked = !this.formatNumberCheckBox.IsChecked;
        }




        /// <summary>
        /// Metoda wywołująca się w momencie gdy stan checkbox'a <see cref=formatNumberCheckBox"/> się zmieni.
        /// Metoda ta zmienia sposób wyświetlania skonwertowanej liczby w aplikacji na podstawie stanu checkbox'a.
        /// Jeżeli checkbox jest aktywny, wówczas formatowanie jest aplikowane. Jesli nie, wówczas liczba jest wyświetlana normalnie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatNumberCheckBox_Change(object sender, RoutedEventArgs e)
        {
            this.convertedValueLabel.Content = ((bool) formatNumberCheckBox.IsChecked)
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
    }
}
