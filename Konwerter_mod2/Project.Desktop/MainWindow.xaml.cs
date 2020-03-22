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

namespace Project.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputT = InputValue.Text;
            string inputU1 = InputUnit1.Text;
            string inputU2 = InputUnit2.Text;
            int k = 0, j = 0;
            List<IKonwerter> Konwertery = new List<IKonwerter>()
            {
                new LenKonwerter(),
                new TempKonwerter(),
                new MassKonwerter(),
                new PowKonwerter()
            };




            foreach (IKonwerter I in Konwertery)
            {
                foreach (string t in I.Units)
                {
                    if (inputU1 == t)
                    {
                        foreach (string b in I.Units)
                        {
                        
                            if (inputU2 == b)
                            {
                                Output.Text = "Wartość otrzymana z " + inputU1 + " do " + inputU2 + " to " + I.VarUnit(Convert.ToDouble(inputT), k).ToString();
                            }
                            if(t!=b)k++;

                        }
                        
                    }
                    j++;
                    k = (I.Units.Count - 1) * j;
                }
                k = 0;
                j = 0;
            }
        }
    }
}
