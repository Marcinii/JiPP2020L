using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace Przelicznik.Controls
{
    public partial class OcenaKontrolka : UserControl
    {
        public int OcenaUzytkownika = 0;
        public OcenaKontrolka()
        {
            InitializeComponent();
        }
        public event EventHandler<PrzesylaneArgumenty> OcenaZmienionaEvent;

        public class PrzesylaneArgumenty : EventArgs
        {
            public int WysylanaOcena { get; set; }
        }


        public void Zresetuj()
        {
            foreach (Ellipse gwiazdka in OcenyWidok.Children)
            {
                gwiazdka.Fill = new SolidColorBrush(Color.FromRgb(0xdb, 0x4c, 0x40));
            }
        }

        public void UstawKolor(int ile)
        {
            Zresetuj();
            int i = 0;
            foreach (Ellipse e in OcenyWidok.Children)
            {
                if (i++ == ile) { break; }
                e.Fill = new SolidColorBrush(Color.FromRgb(0xff, 0xcf, 0x99));
            }
        }
        private void OcenaKlikniecie(object sender, MouseButtonEventArgs e)
        {
            var kolumna = ((Ellipse)sender).GetValue(Grid.ColumnProperty);
            this.OcenaUzytkownika = (int)kolumna + 1;

            OcenaZmienionaEvent(sender, new PrzesylaneArgumenty() { WysylanaOcena = this.OcenaUzytkownika });
        }
    }
}
