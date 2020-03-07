using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UnitConverter.OperationUtil;
using UnitConverter.UnitUtil;
using UnitConverterApp.Util;

namespace UnitConverterApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private OperationRepository operationRepository;
        private MainWindowUtils mainWindowUtils;
        private StatusBarUtils statusBarUtils;
        public Operation operation;
        public Unit fromUnit;
        public Unit toUnit;

        public MainWindow()
        {
            this.mainWindowUtils = new MainWindowUtils(this);
            this.statusBarUtils = new StatusBarUtils(this);
            this.operationRepository = new OperationRepository();

            InitializeComponent();

            OperationRepositoryInitializer.initializeRepository(this.operationRepository);
            this.statusBarUtils.initStatusBarHelp();

            this.mainWindowUtils.resetForm();
            this.operationRepository.operations.ForEach(operation =>
            {
                this.measurementUnitComboBox.Items.Add(operation.name);
            });

            for(int i = 0; i <= 7; i++)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = i;
                this.commaDigitCountComboBox.Items.Add(item);
            }
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

            this.convertedValueGrid.Visibility = Visibility.Hidden;
            this.operation = this.operationRepository.operations[this.measurementUnitComboBox.SelectedIndex];

            this.fromUnitListBox.IsEnabled = true;
            this.toUnitListBox.IsEnabled = true;

            this.fromUnitListBox.Items.Clear();
            this.toUnitListBox.Items.Clear();
            this.operation.units.ForEach(unit =>
            {
                this.fromUnitListBox.Items.Add(unit.name);
                this.toUnitListBox.Items.Add(unit.name);
            });
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
            }
            else if(!Regex.IsMatch(value, @"^[-]?[0-9]+((\.|\,)[0-9]+)?$"))
            {
                this.providedValueTextBox.Background = Brushes.Red;
            }
            else
            {
                this.providedValueTextBox.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFABADB3");
                this.providedValueTextBox.Background = Brushes.White;
                this.convertedValueGrid.Visibility = Visibility.Visible;
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
    }
}
