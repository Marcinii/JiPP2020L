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
using application;
using System.Globalization;

namespace application
{
  
    public partial class Page1 : Page
    {

        public static void InsertData(string name,string uf, string ut, string vf, string vt)
        {
            using (DB context = new DB())
            {
                StatTable stats = new StatTable()
                {
                    ConverterType = name,
                    UnitFrom = uf,
                    UnitTo = ut,
                    ValueFrom = vf,
                    ValueTo = vt,
                    ClickDate = DateTime.Now
                };

                context.StatTable.Add(stats);
                context.SaveChanges();
            }
        }

        //-------------------------------------------


        public Page1()
        {
            InitializeComponent();  
        }


        private void btnGoBackMainPage_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page0());
        }

        private void btnGoCheckTme_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page3());
        }


        private void cmbChoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void enterValText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            txtEnterValue.Text = " ";
            labelResult.Content = " ";
            cmbChoice.Text = String.Empty;
        }


        private void btnTime_Click(object sender, RoutedEventArgs e)
        {
            cTime time = new cTime();
            cmbChoice.ItemsSource = time.UnitsList;
            cmbChoice.SelectedIndex = 0;
        }

        private void btnTemp_Click(object sender, RoutedEventArgs e)
        {
            cTemperature temp = new cTemperature();
            cmbChoice.ItemsSource = temp.UnitsList;
            cmbChoice.SelectedIndex = 0;
        }

        private void btnDist_Click(object sender, RoutedEventArgs e)
        {
            cDistance dist = new cDistance();
            cmbChoice.ItemsSource = dist.UnitsList;
            cmbChoice.SelectedIndex = 0;

        }

        private void btnWeight_Click(object sender, RoutedEventArgs e)
        {
            cWeight weight = new cWeight();
            cmbChoice.ItemsSource = weight.UnitsList;
            cmbChoice.SelectedIndex = 0;
        }

 

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
         

            string tmp = txtEnterValue.Text;
            double outcome = Double.Parse(tmp, CultureInfo.InvariantCulture);
            object returnComboValue = cmbChoice.SelectedValue;
            string changeObject = Convert.ToString(returnComboValue);
            object returnComboIndex = cmbChoice.SelectedIndex;
            int index = Convert.ToInt32(returnComboIndex);

            double returntimeValHtoM()
            { outcome *= 60;return outcome; }
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

            string a = " ";
            string b = " ";

            if (changeObject == "km --> miles")
            {
                a = "km";
                b = "miles";
                returnFinalValue = returndistValKmtoMiles();
            }
            if (changeObject == "miles --> km")
            {
                a = "miles";
                b = "km";
                returnFinalValue = returndistValMilestoKM();
            }
            if (changeObject == "m --> mm")
            {
                a = "m";
                b = "mm";
                returnFinalValue = returndistValMtoMM();
            }
            if (changeObject == "mm --> m")
            {
                a = "mm";
                b = "m";
                returnFinalValue = returndistValMMtoM();
            }
            if (changeObject == "hours --> minutes")
            {
                a = "hours";
                b = "minutes";
                returnFinalValue = returntimeValHtoM();
            }
            if (changeObject == "minutes --> hours")
            {
                a = "minutes";
                b = "hours";
                returnFinalValue = returntimeValMtoH();
            }
            if (changeObject == "Celsius --> Farenheit")
            {
                a = "Celsius";
                b = "Farenheit";
                returnFinalValue = returntempValCtoF();
            }
            if (changeObject == "Farenheit --> Celsius")
            {
                a = "Farenheit";
                b = "Celsius";
                returnFinalValue = returntempValFtoC();
            }
            if (changeObject == "pounds --> kg")
            {
                a = "pounds";
                b = "kg";
                returnFinalValue = returnweightValPtoKG();
            }
            if (changeObject == "kg --> pounds")
            {
                a = "kg";
                b = "pounds";
                returnFinalValue = returnweightValKGtoP();
            }

            labelResult.Content = Math.Round(outcome, 2);

            //-------------------------

            string c = " ";

            string what()
            {
                if (a == "kg" || b == "kg") c = "weight";
                if (a == "Celsius" || b == "Celsius") c = "temperature";
                if (a == "hours" || b == "hours") c = "time";
                if (a == "km" || b == "km") c = "distance";
                return c;
            }

            string cfinal = what();
            string coutcome = Convert.ToString(outcome);
            //    string name (,string uf, string ut, string vf, string vt
            InsertData(cfinal, a, b, tmp, coutcome);

        }

        private void btnStatisticsMain_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page4());
            
        }
    }



 }

