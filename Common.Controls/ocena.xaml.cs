using System;
using System.Collections.Generic;
using System.Linq;
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

    public partial class ocena : UserControl
    {
        public ocena()
        {
            InitializeComponent();
        }

        private int _ocenaWartosc = 0;

        public event EventHandler<RateEventArgs> OcenaWartoscZmiana;

        private void AktualizacjaPrzyciskow()
        {
            foreach(var b in ocenaGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            int i = _ocenaWartosc;
            while (i>0)
            {
                ((Button)ocenaGrid.Children[i - 1]).Background = new SolidColorBrush(Colors.Yellow);
                i--;
            }
        }

        private void AktualizacjaPrzyciskowBialy()
        {
            foreach (var b in ocenaGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
        }

        public int OcenaWartosc
        {
            get { return _ocenaWartosc; }
            set 
            {
                if (value >= 0 && value <= 5)
                {
                    if (_ocenaWartosc == value)
                    { AktualizacjaPrzyciskowBialy(); _ocenaWartosc = 0; }
                    else { _ocenaWartosc = value; AktualizacjaPrzyciskow(); }
                }

                if (OcenaWartoscZmiana != null)
                {
                    OcenaWartoscZmiana(this, new RateEventArgs() { Value = _ocenaWartosc });
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OcenaWartosc = ocenaGrid.Children.IndexOf((Button)sender) + 1;
        }


        public class RateEventArgs: EventArgs
        {
            public int Value { get; set; }
        }
    }
}
