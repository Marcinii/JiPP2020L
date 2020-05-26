using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnitConverter.Application.AppUserControl.PaginationSwitcherControl;
using UnitConverter.Application.Command;
using UnitConverter.Application.Util;
using UnitConverter.Library.OperationUtil;
using UnitConverter.Library.OperationUtil.Repository;
using UnitConverter.Library.TypeUtil;
using UnitConverter.Library.TypeUtil.DateTimeType;
using UnitConverter.Library.TypeUtil.Number;
using UnitConverter.Library.TypeUtil.TypeException;

namespace UnitConverter.Application.AppWindow
{
    /// <summary>
    /// Okno, które ma za zadanie wyświetlenie historii wykonywanych konwersji
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        private StatusBarUtils statusBarUtils;
        private TextBoxUtils converterNameTextBoxUtils;
        private TextBoxUtils fromDateTextBoxUtils;
        private TextBoxUtils toDateTextBoxUtils;

        private Operation selectedOperation;

        private OperationRepository repository;

        private bool dataFiltered;




        public StatisticsWindow()
        {
            InitializeComponent();

            this.DataContext = this;

            this.statusBarUtils = new StatusBarUtils(this.helperTextStatusBar);

            this.statusBarUtils.addStatusBarText(this.statisticsWindowCloseMenuItem, "Zamyka bieżące okno");
            this.statusBarUtils.addStatusBarText(this.converterNameTextBox, "Wprowadź nazwę konwertera");
            this.statusBarUtils.addStatusBarText(this.fromDateTextBox, "Wprowadź datę poczatkową");
            this.statusBarUtils.addStatusBarText(this.toDateTextBox, "Wprowadź datę końcową");


            this.converterNameTextBoxUtils = new TextBoxUtils(this.converterNameTextBox);
            this.fromDateTextBoxUtils = new TextBoxUtils(this.fromDateTextBox);
            this.toDateTextBoxUtils = new TextBoxUtils(this.toDateTextBox);


            this.repository = ((App)System.Windows.Application.Current).repository;

            this.repository.selectOperation(2);
            this.selectedOperation = this.repository.getSelectedOperation();


            this.selectedOperation.task.setParameter("currentPage", paginationSwitcher.currentPage);
            this.selectedOperation.task.setParameter("pageSize", (CustomInteger)20);
            this.selectedOperation.task.setParameter("spinner", this.statisticsWindowLoadingSpinner);
            this.selectedOperation.task.setParameter("statisticsWindow", this);


            new Thread(() => this.selectedOperation.run()).Start();

            this.dataFiltered = false;

            this.filterDataButton.Command = new ButtonCommand(
                    x => applyFilter(),
                    x => (!this.fromDateTextBoxUtils.isNullOrEmpty() && this.fromDateTextBoxUtils.valid) ||
                         (!this.toDateTextBoxUtils.isNullOrEmpty() && this.toDateTextBoxUtils.valid) ||
                         !this.converterNameTextBoxUtils.isNullOrEmpty()
            );


            this.clearFilterButton.Command = new ButtonCommand(
                x => clearFilter(),
                x => this.dataFiltered
            );
        }



        /// <summary>
        /// Metoda, która ma za zadanie oświeżenie rezultatu tabeli.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshWindowMenuItem_Click(object sender, RoutedEventArgs e) => 
            new Thread(() => this.selectedOperation.run()).Start();



        /// <summary>
        /// Metoda, która zamyka okno (nie zamykając jednocześnie całej aplikacji)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statisticsWindowCloseMenuItem_Click(object sender, RoutedEventArgs e) => this.Close();



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
            if (e.Source is Control)
            {
                this.statusBarUtils.setStatusBarText((Control)e.Source);
            }
        }



        /// <summary>
        /// Metoda, która wywoływana jest w momencie, gdy dojdzie do zmiany wartości pola tekstowego <see cref="converterNameTextBox"/>.
        /// Ma ona za zadanie uaktualnienie parametru, którego wartość odpowiada nazwie wkonanej konwersji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void converterNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.selectedOperation.task.setParameter("Nazwa konwertera", (CustomString)this.converterNameTextBox.Text);
        }



        /// <summary>
        /// Metoda, która jest wywoływana w momencie, gdy dojdzie do zmiany wartości pola tekstowego <see cref="fromDateTextBox"/>.
        /// Ma ona za zadanie uaktualnienie parametru, którego wartość odpowiada dacie początkowej zakresu dat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fromDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.fromDateTextBoxUtils.setToValid();

                this.selectedOperation.task.setParameter(
                    "Data początkowa",
                    this.fromDateTextBoxUtils.isNullOrEmpty() ? new CustomDate() : fromDateTextBox.Text
                );
            }
            catch (CustomTypeException)
            {
                this.fromDateTextBoxUtils.setToInvalid();
            }
        }



        /// <summary>
        /// Metoda, która jest wywoływana w momencie, gdy dojdzie do zmiany wartości pola tekstowego <see cref="toDateTextBox"/>.
        /// Ma ona za zadanie uaktualnienie parametru, którego wartość odpowiada dacie końcowej zakresu dat.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                this.toDateTextBoxUtils.setToValid();

                this.selectedOperation.task.setParameter(
                    "Data końcowa",
                    this.toDateTextBoxUtils.isNullOrEmpty() ? new CustomDate() : toDateTextBox.Text
                );
            }
            catch(CustomTypeException)
            {
                this.toDateTextBoxUtils.setToInvalid();
            }
        }



        /// <summary>
        /// Metoda, która jest wywoływana w momencie, gdy dojdzie do zmiany numeru strony w elemencie <see cref="paginationSwitcher"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <see cref="PaginationSwitcherEventArgs"/>
        private void paginationSwitcher_onChange(object sender, PaginationSwitcherEventArgs args)
        {
            this.selectedOperation.task.setParameter("currentPage", args.currentPage);
            this.selectedOperation.run();
        }



        /// <summary>
        /// Metoda, która jest wywoływana w momencie kliknięcia na przycisk <see cref="filterDataButton"/>.
        /// Metoda ta ma za zadanie zatwierdzić filtrowanie danych według wprowadzonych pół.
        /// </summary>
        private void applyFilter()
        {
            new Thread(() =>
            {
                this.selectedOperation.run();
                Dispatcher.Invoke(() =>
                {
                    this.paginationSwitcher.reset();
                    this.dataFiltered = true;
                });
            }).Start();
        }



        /// <summary>
        /// Metoda, któa jest wywoływanaa w momencie kliknięcia przycisku <see cref="clearFilterButton"/>.
        /// Metoda ta restartuje wprowadzone wartości do filtra danych i z powrotem wyświetla wszystkie statystyki
        /// </summary>
        private void clearFilter()
        {
            this.converterNameTextBoxUtils.clear();
            this.fromDateTextBoxUtils.clear();
            this.toDateTextBoxUtils.clear();

            this.selectedOperation.task.setParameter("Nazwa konwertera", new CustomString());
            this.selectedOperation.task.setParameter("Data początkowa", new CustomDate());
            this.selectedOperation.task.setParameter("Data końcowa", new CustomDate());

            this.dataFiltered = false;

            this.applyFilter();
        }
    }
}
