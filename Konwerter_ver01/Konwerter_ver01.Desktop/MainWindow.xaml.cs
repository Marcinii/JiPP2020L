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
            JednZtemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
            JednDotemp.ItemsSource = new Konwerter_ver01.ConTemp().Jedn;
            JednZodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
            JednDoodl.ItemsSource = new Konwerter_ver01.ConOdl().Jedn;
            JednZwag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
            JednDowag.ItemsSource = new Konwerter_ver01.ConWag().Jedn;
            JednZspe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
            JednDospe.ItemsSource = new Konwerter_ver01.ConSpe().Jedn;
        }


    }

    /* private void Wykonaj_Click(object sender, RoutedEventArgs e)
     {
         string input = JednDoBox.Text;
         string output = "To" + input; 
             JednZBox.Text = output;
     }*/
}

