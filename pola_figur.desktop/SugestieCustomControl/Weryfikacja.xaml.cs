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

namespace SugestieCustomControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Random rnd = new Random();            
            int a = rnd.Next(1, 10);
            int b = rnd.Next(1, 10);
            string v = a.ToString();
            A_Label.Content = v;
            string x = b.ToString();
            B_Label.Content = x;            
        }
        public class RateEventArgs : EventArgs
        {
            public bool Value { get; set; }
        }
        private bool _Weryfikacja = false;

        public event EventHandler<RateEventArgs> Wartosc_Weryfikacji_Changed;

        public bool Weryfikacja
        {
            get { return _Weryfikacja; }
            set
            {
                _Weryfikacja = value;
                Wartosc_Weryfikacji_Changed?.Invoke(this, new RateEventArgs() { Value = _Weryfikacja });
            }
        }

        private void Weryfikacja_Button_Click(object sender, RoutedEventArgs e)
        {
            int a;
            if (int.TryParse(A_Label.Content.ToString(), out a)) { } ;
            int b;
            if (int.TryParse(B_Label.Content.ToString(), out b)) { } ;
            int wyn = a + b;
            int wynik;
            if (int.TryParse(Result_TextBox.Text.ToString(), out wynik))
            {
                if(wynik == wyn)
                {
                    Weryfikacja = true;
                }                
            }
        }
    }
}
