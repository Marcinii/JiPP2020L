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
using Konwerter_ver01;


namespace Konwerter_ver01.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            WybKon.ItemsSource = new ZestawKonw().GetConverter();

            //CykCyk.Angle = 6;
            /* JednZtemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednDotemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
             JednZodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednDoodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
             JednZwag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednDowag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
             JednZspe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             JednDospe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
             */
        }

        private void WybKon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            JednZ.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;
            JednDo.ItemsSource = ((IConverter)WybKon.SelectedItem).Jedn;            
        }

        private void Wykonajtemp_Click(object sender, RoutedEventArgs e)
        {
            string inputDane = Dane.Text;
            //double inputValue;
            //double.TryParse(inputDane, out inputValue);
            var result = ((IConverter)WybKon.SelectedItem).Convert(JednZ.SelectedItem.ToString(), JednDo.SelectedItem.ToString(), inputDane);
            ((Storyboard)Resources["StoryboardJajo"]).Stop();
            Wynik.Text = result.ToString();
        }

        private void WynikButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["StoryboardJajo"]).Begin();
            string inputDane = Dane.Text;
            var result = ((IConverter)WybKon.SelectedItem).Convert(JednZ.SelectedItem.ToString(), JednDo.SelectedItem.ToString(), inputDane);
            WynikGraf.Text = result.ToString() + " " + JednDo.SelectedItem.ToString();
        

       
        if (Convert.ToString(JednZ.SelectedItem) == "24h" && Convert.ToString(JednDo.SelectedItem) == "12h")
            {
                int cyk, pyk;

        int index = result.IndexOf(":");
                if (index == 1)
                {
                     pyk = Convert.ToInt32(result.Substring(0,1));
                     cyk = Convert.ToInt32(result.Substring(2, 2));
                }
                else
                {
                     pyk = Convert.ToInt32(result.Substring(0, 2));
                     cyk = Convert.ToInt32(result.Substring(3, 2));
                }

                cyk *= 6;
                pyk *=30;
                
                Pokaz_Zegar(cyk, pyk);
            }
            if (Convert.ToString(JednZ.SelectedItem) == "12h" && Convert.ToString(JednDo.SelectedItem) == "24h")
            {
                int cyk, pyk;

                int index = result.IndexOf(":");
                if (index == 1)
                {
                    pyk = Convert.ToInt32(result.Substring(0, 1));
                    cyk = Convert.ToInt32(result.Substring(2, 2));
                }
                else
                {
                    pyk = Convert.ToInt32(result.Substring(0, 2));
                    cyk = Convert.ToInt32(result.Substring(3, 2));
                }

                cyk *= 6;
                pyk *= 30;

                Pokaz_Zegar(cyk, pyk);
            }
        }
        private void Pokaz_Zegar(double cyk, double pyk)
        {
            PykPyk.Angle = pyk;
            CykCyk.Angle = cyk;
        }
           
        

        /*private void PokazWynikButton_Click(object sender, RoutedEventArgs e)
        {
            ((Storyboard)Resources["StoryboardKom12"]).Begin();
        }*/
    }
}

