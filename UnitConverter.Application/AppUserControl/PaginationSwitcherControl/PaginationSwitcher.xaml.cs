using System.Windows;
using System.Windows.Controls;
using UnitConverter.Application.Command;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Application.AppUserControl.PaginationSwitcherControl
{
    /// <summary>
    /// Kontrolka, która ma za zadanie przełączać tabelę danych między stronami.
    /// Wykorzystywany jest w momencie, gdy mamy ustawiony limit ilości wyświetlanych wierszy w tabeli.
    /// </summary>
    /// <param name="onChange">
    ///     Pole, które przechowuje referencje do metod, które będą wywoływane w momencie, gdy
    ///     zostanie wywołane to pole. Pole to jest wywoływane w momencie, gdy dojdzie do
    ///     zmiany numeru strony.
    /// </param>
    /// <param name="currentPage">Aktualny numer strony</param>
    /// <param name="pages">Liczba stron</param>
    public partial class PaginationSwitcher : UserControl
    {
        public event PaginationSwitcherEventHandler onChange;

        public CustomInteger currentPage
        {
            get => (CustomInteger)GetValue(currentPageProperty);
            set {
                SetValue(currentPageProperty, value);
                this.onChange?.Invoke(this, new PaginationSwitcherEventArgs(value));
            }
        }
        
        public static readonly DependencyProperty currentPageProperty =
            DependencyProperty.Register(
                "currentPage", typeof(CustomInteger), typeof(PaginationSwitcher), new PropertyMetadata(new CustomInteger(1))
            );





        public CustomInteger pages
        {
            get => (CustomInteger)GetValue(pagesProperty);
            set => SetValue(pagesProperty, value);
        }

        public static readonly DependencyProperty pagesProperty =
            DependencyProperty.Register("pages", typeof(CustomInteger), typeof(PaginationSwitcher), new PropertyMetadata(new CustomInteger()));





        public PaginationSwitcher()
        {
            InitializeComponent();

            this.DataContext = this;

            this.firstPageButton.Command = new ButtonCommand(
                x => reset(), x => currentPage > 1
            );

            this.previousPageButton.Command = new ButtonCommand(
                x => previousPage(), x => currentPage > 1
            );

            this.nextPageButton.Command = new ButtonCommand(
                x => nextPage(), x => currentPage < this.pages
            );

            this.lastPageButton.Command = new ButtonCommand(
                x => lastPage(), x => currentPage < this.pages
            );
        }



        /// <summary>
        /// Metoda ma za zadanie restartować numer strony
        /// </summary>
        public void reset() => this.currentPage = 1;



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na poprzednią
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPage() => currentPage--;



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na następną
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPage() => currentPage++;



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na ostanią stronę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastPage() => this.currentPage = this.pages;
    }
}
