using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.UnitUtil;
using UnitConverter.App.Util;
using UnitConverterApp.Util;

namespace UnitConverter.App
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OperationRepository operationRepository;
        private MainWindowUtils mainWindowUtils;
        private StatusBarUtils statusBarUtils;
        private DoubleUtils doubleUtils;
        public Operation operation;
        public Unit fromUnit;
        public Unit toUnit;



        public MainWindow()
        {
            InitializeComponent();

            this.doubleUtils = new DoubleUtils();
            this.operationRepository = new OperationRepository();
            this.mainWindowUtils = new MainWindowUtils(this, this.doubleUtils);
            this.statusBarUtils = new StatusBarUtils(this.helperTextStatusBar);

            OperationRepositoryInitializer.initializeRepository(this.operationRepository);

            this.statusBarUtils.addStatusBarText(this.measurementUnitComboBox, "Wprowadż wartość do skonwertowania");
            this.statusBarUtils.addStatusBarText(this.providedValueTextBox, "Wprowadź wartość do przekonwertowania");
            this.statusBarUtils.addStatusBarText(this.fromUnitListBox, "Wybierz jednostkę, z której chcesz skonwertować liczbę");
            this.statusBarUtils.addStatusBarText(this.toUnitListBox, "Wybierz jednostkę, na którą chcesz skonwertować liczbę");
            this.statusBarUtils.addStatusBarText(this.swapButton, "Zamień jednosti miejscami");
            this.statusBarUtils.addStatusBarText(this.commaDigitCountComboBox, "Wybierz liczbę widocznych cyfer po przecinku");
            this.statusBarUtils.addStatusBarText(this.formatNumberCheckBox, "Dzieli liczbę przed przecinkiem co 3 cyfry, by liczba była czytelniejsza");

            this.mainWindowUtils.resetForm();

            ComboBoxUtils<string> measurementUnitComboBoxUtils = new ComboBoxUtils<string>();
            measurementUnitComboBoxUtils.initialize(
                this.measurementUnitComboBox, 
                this.operationRepository.operations.Select(item => item.name).ToList()
            );

            ComboBoxUtils<int> commaDigitCountComboBoxUtils = new ComboBoxUtils<int>();
            commaDigitCountComboBoxUtils.initialize(
                this.commaDigitCountComboBox,
                Enumerable.Range(0,8).ToList()
            );

            this.commaDigitCountComboBox.SelectedIndex = 3;
        }




        /// <summary>
        /// Metoda wykonująca się w momencie, gdy zostanie wywołane zdarzenie zmiany aktualnego wybranego elementu z listy "" <see cref="measurementUnitComboBox"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void measurementUnitComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.mainWindowUtils.resetForm();

            this.operation = this.operationRepository.operations[this.measurementUnitComboBox.SelectedIndex];

            this.fromUnitListBox.IsEnabled = true;
            this.toUnitListBox.IsEnabled = true;

            this.fromUnitListBox.Items.Clear();
            this.toUnitListBox.Items.Clear();

            ListBoxUtils<string> fromUnitListBoxUtils = new ListBoxUtils<string>();
            fromUnitListBoxUtils.initialize(
                this.fromUnitListBox,
                this.operation.units.Select(item => item.name).ToList()
            );

            ListBoxUtils<string> toUnitListBoxUtils = new ListBoxUtils<string>();
            toUnitListBoxUtils.initialize(
                this.toUnitListBox,
                this.operation.units.Select(item => item.name).ToList()
            );
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

            this.fromUnit = this.operation.units[this.fromUnitListBox.SelectedIndex];
            if(this.toUnit != null)
            {
                this.providedValueTextBox.IsEnabled = true;
                this.swapButton.IsEnabled = true;
                this.commaDigitCountComboBox.IsEnabled = true;

                this.mainWindowUtils.updateConvertedLabel();
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

            this.toUnit = this.operation.units[this.toUnitListBox.SelectedIndex];
            if (this.fromUnit != null)
            {
                this.providedValueTextBox.IsEnabled = true;
                this.swapButton.IsEnabled = true;
                this.commaDigitCountComboBox.IsEnabled = true;

                this.mainWindowUtils.updateConvertedLabel();
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

            if(value == null || value == "")
            {
                this.convertedValueLabel.Content = "0";
                this.providedValueTextBox.Background = Brushes.White;
                this.formatNumberCheckBox.IsEnabled = false;
                this.formatNumberLabel.Cursor = Cursors.Arrow;
            }
            else if(!Regex.IsMatch(value, @"^[-]?[0-9]+((\.|\,)[0-9]+)?$"))
            {
                this.providedValueTextBox.Background = Brushes.Red;
                this.formatNumberCheckBox.IsEnabled = false;
                this.formatNumberLabel.Cursor = Cursors.Arrow;
            }
            else
            {
                this.providedValueTextBox.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFABADB3");
                this.providedValueTextBox.Background = Brushes.White;
                this.convertedValueGrid.Visibility = Visibility.Visible;
                this.formatNumberCheckBox.IsEnabled = true;
                this.formatNumberLabel.Cursor = Cursors.Hand;
                this.mainWindowUtils.updateConvertedLabel();
            }
        }




        /// <summary>
        /// Metoda wywołująca się w momencie, gy przycisk <see cref="swapButton"/> zostanie kliknięty.
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
        /// Metoda wykonująca się w momencie, gdy dojdzie do zmiany aktualnie zaznaczonego elementu w liście rozwijanej <see cref="commaDigitCountComboBox"/>
        /// Metoda ta od razu konwertuje liczbę tylko wtedy, gdy pole tekstowe <see cref="providedValueTextBox" /> jest aktywne (tylko wtedy ma wprowadzoną wartość)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void commaDigitCountComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.commaDigitCountComboBox.IsEnabled)
                this.mainWindowUtils.updateConvertedLabel();
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
            this.mainWindowUtils.updateConvertedLabel();
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
    }
}
