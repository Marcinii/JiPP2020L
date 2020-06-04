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

namespace MottoControl
{
    /// <summary>
    /// Interaction logic for MottoControl.xaml
    /// </summary>
    public partial class MottoControl : UserControl
    {
        List<string> lista = new List<string>
        {
            "Gdyby kózka nie skakała, to by nóżki nie złamała",
            "Bez pracy nie ma kołaczy",
            "Darowanemu koniowi w zęby się nie zagląda",
            "Fortuna kołem się toczy",
            "Nie chwal dnia przed zachodem słońca",
            "Lepszy wróbel w garści niż gołąb na dachu",
            "Apetyt rośnie w miarę jedzenia",
            "Grosz do grosza, a będzie kokosza"
        };
        public MottoControl()
        {
            InitializeComponent();
        }

        private void LosujMottoButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int losowa = rnd.Next(0, lista.Count-1);
            MottoLabel.Content = lista[losowa].ToString();
        }
    }
}
