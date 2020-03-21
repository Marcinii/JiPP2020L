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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Konwerter_jednostek
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CBOpcja.ItemsSource = new KonwerterSerwis().GetConverters();
        }
        private void CBOpcja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBZ.ItemsSource = ((IKonwerter)CBOpcja.SelectedItem).Jednostki;
            CBNa.ItemsSource = ((IKonwerter)CBOpcja.SelectedItem).Jednostki;
            if (((IKonwerter)CBOpcja.SelectedItem).Nazwa == "Czas")
            {
                ((Storyboard)Resources["StoryboardMin"]).Begin();
                ((Storyboard)Resources["StoryboardGodz"]).Begin();
            }
        }

    private void Button1_Click(object sender, RoutedEventArgs e)
        {
             
            string WartoscWe = TBoxWartosc.Text;
            string wartosc = WartoscWe;

            TBlockWynik.Text = (((IKonwerter)CBOpcja.SelectedItem).Konwerter(CBZ.Text, CBNa.Text, wartosc));//.ToString("F");
            if (((IKonwerter)CBOpcja.SelectedItem).Nazwa == "Czas") 
            {
                ((Storyboard)Resources["StoryboardMin"]).Stop();
                ((Storyboard)Resources["StoryboardGodz"]).Stop();
                if (int.TryParse(String.Concat(TBlockWynik.Text[3], TBlockWynik.Text[4]), out int a1)) a1 *= 6; else a1 = 0;
                RotacjaMin.Angle = a1;
                if (int.TryParse(String.Concat(TBlockWynik.Text[0], TBlockWynik.Text[1]), out int a2)) a2 *= 30; else a2 = 0;
                RotacjaGodz.Angle = a2+a1/12.0;
            }
        }
    }
}
