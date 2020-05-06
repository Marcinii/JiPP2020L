using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for RateControl.xaml
    /// </summary>
    public partial class RateControl : UserControl
    {
        public RateControl()
        {
            InitializeComponent();
        }

        private int _Wartosc_Oceny = 0;

        public event EventHandler<RateEventArgs> Wartosc_Oceny_Changed;

        public int Wartosc_Oceny
        {
            get { return _Wartosc_Oceny; }
            set
            {
                if (value < 1 && value > 5)
                {
                    MessageBox.Show("Wybierz poprawną ocene");
                }
                else
                {
                    _Wartosc_Oceny = value;
                    UpdateButtons();
                }
                Wartosc_Oceny_Changed?.Invoke(this, new RateEventArgs() { Value = _Wartosc_Oceny });
            }
        }

        private void UpdateButtons()
        {
            foreach (var b in RateGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
            if (Wartosc_Oceny > 0)
            {
                int tmp = 0;
                foreach (var b in RateGrid.Children)
                {
                    tmp++;
                    if (tmp > Wartosc_Oceny)
                    {
                        break;
                    }
                    ((Button)b).Background = new SolidColorBrush(Colors.Gold);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Wartosc_Oceny = RateGrid.Children.IndexOf((Button)sender) + 1;
        }
    }

    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}