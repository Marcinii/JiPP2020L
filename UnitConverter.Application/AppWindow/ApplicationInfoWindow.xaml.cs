using System.Windows;

namespace UnitConverter.Application.AppWindow
{
    /// <summary>
    /// Okno wyświetlające podstawowe informacje o autorze aplikacji
    /// </summary>
    public partial class ApplicationInfoWindow : Window
    {
        public ApplicationInfoWindow()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Metoda, która zamyka okno (nie zamykając całej aplikacji)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applicationInfoCloseButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
