using System;
using System.Collections;
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
using UnitConverter.Logic;
using System.Globalization;


namespace UnitConverter.Desktop
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
 
        private void timeButton_Click(object sender, RoutedEventArgs e)
        {
            cTime time = new cTime();
            cmbUnitChoice.ItemsSource = time.UnitsList;
            cmbUnitChoice.SelectedIndex = 0;
        }

        private void tempButton_Click(object sender, RoutedEventArgs e)
        {
            cTemperature temp = new cTemperature();
            cmbUnitChoice.ItemsSource = temp.UnitsList;
            cmbUnitChoice.SelectedIndex = 0;
        }

        private void distanceButton_Click(object sender, RoutedEventArgs e)
        {
            cDistance dist = new cDistance();
            cmbUnitChoice.ItemsSource = dist.UnitsList;
            cmbUnitChoice.SelectedIndex = 0;
        }
  
        private void weightButton_Click(object sender, RoutedEventArgs e)
        {
            cWeight weight = new cWeight();
            cmbUnitChoice.ItemsSource = weight.UnitsList;
            cmbUnitChoice.SelectedIndex = 0;
        }

        private void cmbUnitChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void inputValue(object sender, TextChangedEventArgs e)
        {
            string wartosc = Console.ReadLine();
        }

        

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            string tmp = txtEnterValue.Text;
            double outcome = Double.Parse(tmp, CultureInfo.InvariantCulture);
            object returnComboValue = cmbUnitChoice.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = cmbUnitChoice.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            double returntimeValHtoM() { outcome *= 60; return outcome; }
            double returntimeValMtoH() { outcome /= 60; return outcome; }
            double returntempValFtoC() { outcome = ((outcome - 32) / 1.8); return outcome; }
            double returntempValCtoF() { outcome *= 1.8 + 32; return outcome; }
            double returndistValKmtoMiles() { outcome /= 0.62137; return outcome; }
            double returndistValMilestoKM() { outcome *= 0.62137; return outcome; }
            double returndistValMtoMM() { outcome *= 1000; return outcome; }
            double returndistValMMtoM() { outcome /= 1000; return outcome; }
            double returnweightValPtoKG() { outcome /= 2.2046; return outcome; }
            double returnweightValKGtoP() { outcome *= 2.2046; return outcome; }

            double returnFinalValue = 0.0;

       
            if (changeObject == "km --> miles") returnFinalValue = returndistValKmtoMiles();
            if (changeObject == "miles --> km") returnFinalValue = returndistValMilestoKM();
            if (changeObject == "m --> mm") returnFinalValue = returndistValMtoMM();
            if (changeObject == "mm --> m") returnFinalValue = returndistValMMtoM();
            if (changeObject == "hours --> minutes") returnFinalValue = returntimeValHtoM();
            if (changeObject == "minutes --> hours") returnFinalValue = returntimeValMtoH();
            if (changeObject == "Celsius --> Farenheit") returnFinalValue = returntempValCtoF();
            if (changeObject == "Farenheit --> Celsius") returnFinalValue = returntempValFtoC();
            if (changeObject == "pounds --> kg") returnFinalValue = returnweightValPtoKG();
            if (changeObject == "kg --> pounds") returnFinalValue = returnweightValKGtoP();

            labelResult.Content = Math.Round(outcome, 2);
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, RoutedEventArgs e)
        {
            txtEnterValue.Text = " ";
            labelResult.Content = " ";
            cmbUnitChoice.Text = String.Empty;
        }
    }

}

    

           
           

