using System.Windows;
using System.Windows.Controls;
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
            get { return (CustomInteger)GetValue(currentPageProperty); }
            set {
                this.firstPageButton.IsEnabled = value > 1;
                this.previousPageButton.IsEnabled = value > 1;
                this.lastPageButton.IsEnabled = value < this.pages;
                this.nextPageButton.IsEnabled = value < this.pages;

                SetValue(currentPageProperty, value);
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

            this.firstPageButton.IsEnabled = currentPage != 1;
            this.previousPageButton.IsEnabled = currentPage != 1;
            this.lastPageButton.IsEnabled = currentPage != this.pages;
            this.nextPageButton.IsEnabled = currentPage != this.pages;

            this.DataContext = this;
        }



        /// <summary>
        /// Metoda, która ma za zadanie zmienić numer strony na pierwszą stronę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentPage = 1;
            this.onChange?.Invoke(this, new PaginationSwitcherEventArgs(this.currentPage));
        }



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na poprzednią
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void previousPageButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage--;
            this.onChange?.Invoke(this, new PaginationSwitcherEventArgs(this.currentPage));
        }



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na następną
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextPageButton_Click(object sender, RoutedEventArgs e)
        {
            currentPage++;
            this.onChange?.Invoke(this, new PaginationSwitcherEventArgs(this.currentPage));
        }



        /// <summary>
        /// Metoda, która ma za zadanie ustawić numer strony na ostanią stronę
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastPageButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentPage = this.pages;
            this.onChange?.Invoke(this, new PaginationSwitcherEventArgs(this.currentPage));
        }
    }
}
