using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BankApplication.GUI.AppUserControl.AccountListItemControl
{
    /// <summary>
    /// Interaction logic for AccountListItem.xaml
    /// </summary>
    /// <param name="onChecked">Zdarzenie, które zostanie wywołane w momencie zmieniania stanu zaznaczenia kontrolki</param>
    /// <param name="text">Wyświetlany tekst</param>
    /// <param name="selected">Pole przechowujące informacje o tym, czy dana kontrolka została zaznaczona</param>
    /// <param name="borderColor">Kolor obramowania kontrolki</param>
    public partial class AccountListItem : UserControl
    {
        public event EventHandler onChecked;

        public string text
        {
            get { return (string)GetValue(textProperty); }
            set { SetValue(textProperty, value); }
        }

        public static readonly DependencyProperty textProperty =
            DependencyProperty.Register("text", typeof(string), typeof(AccountListItem), new PropertyMetadata(""));




        public bool selected
        {
            get { return (bool)GetValue(selectedProperty); }
            set { 
                SetValue(selectedProperty, value);
                this.borderColor = value ? (SolidColorBrush)new BrushConverter().ConvertFrom("#FF00AEFF") : Brushes.Transparent;
            }
        }

        public static readonly DependencyProperty selectedProperty =
            DependencyProperty.Register("selected", typeof(bool), typeof(AccountListItem), new PropertyMetadata(false));




        public Brush borderColor
        {
            get { return (Brush)GetValue(borderColorProperty); }
            set { SetValue(borderColorProperty, value); }
        }

        public static readonly DependencyProperty borderColorProperty =
            DependencyProperty.Register("borderColor", typeof(Brush), typeof(AccountListItem), new PropertyMetadata(Brushes.Transparent));





        public AccountListItem()
        {
            InitializeComponent();
            this.DataContext = this;
        }





        /// <summary>
        /// Metoda, która zostanie wywołana w momencie kliknięcia na nią myszką. Metoda ma za zadanie zmienić stan
        /// wartości pola <see cref="selected"/> oraz wywołania zdarzenia <see cref="onChecked"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainAccountItemGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.selected = !this.selected;
            this.onChecked?.Invoke(this, EventArgs.Empty);
        }
    }
}
