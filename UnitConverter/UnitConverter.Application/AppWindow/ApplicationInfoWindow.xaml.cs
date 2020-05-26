using System.Windows;
using UnitConverter.Application.Command;

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

            this.applicationInfoCloseButton.Command = new ButtonCommand(
                x => this.Close()
            );
        }
    }
}
