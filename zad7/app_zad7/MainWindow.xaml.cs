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
using bmi_logic;

namespace app_zad7
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Bmi_calculator calc = new Bmi_calculator();
        float weight;
        float height;

        private void bmi_confirm_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                weight = float.Parse(weight_box.Text);
                height = float.Parse(height_box.Text);
                if(height > 0 && weight > 0)
                {
                    bmi_text_box.Text = "Twoje BMI to: " + calc.calculate_bmi(weight, height);
                }
                else
                {
                    bmi_text_box.Text = "Niepoprawne dane.";
                }
                
            }
            catch
            {
                bmi_text_box.Text = "Niepoprawne dane.";
            }

        }
    }
}
