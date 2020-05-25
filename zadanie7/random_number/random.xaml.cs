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

namespace random_number
{
    /// <summary>
    /// Logika interakcji dla klasy random.xaml
    /// </summary>
    public partial class random : UserControl
    {
        public random()
        {
            InitializeComponent();
            var rand = new Random();
            Console.WriteLine("Five random integers between 0 and 100:");
            generator.Text = rand.Next(1000).ToString();
        }
    }
}
