using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace KonwerterJednostek.Kontrolki
{
    public partial class KontrolkaOceny : UserControl
    {
        public int OcenaUzytkownika = 0;
        public KontrolkaOceny()
        {
            InitializeComponent();
        }
        public event EventHandler<PrzesylaneArgumenty> OcenaUleglaZmianie;

        public class PrzesylaneArgumenty : EventArgs
        {
            public int OcenaUzytkownika { get; set; }
        }

        public void Zakoloruj(int ile)
        {
            Resetuj();
            int i = 0;
            foreach (Ellipse e in UkladOcen.Children)
            {
                if (i++ == ile) { break; }
                e.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
        }

        public void Resetuj()
        {
            foreach (Ellipse e in UkladOcen.Children)
                e.Fill = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }



        private void OcenaKliknieta(object sender, MouseButtonEventArgs e)
        {
            var column = ((Ellipse)sender).GetValue(Grid.ColumnProperty);
            this.OcenaUzytkownika = (int)column + 1;

            OcenaUleglaZmianie(sender, new PrzesylaneArgumenty() { OcenaUzytkownika = this.OcenaUzytkownika });
        }
    }
}
