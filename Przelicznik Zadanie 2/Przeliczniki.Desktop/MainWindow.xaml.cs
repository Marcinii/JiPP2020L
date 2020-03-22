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
using ConsoleApp2;

namespace Przeliczniki.Desktop
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
        private void TempCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.userInputTemp.Text != null && this.TempZ.SelectedValue != null && this.TempDo.SelectedValue != null)
            {
                Temperatury przelicznik = new Temperatury();
                double liczba = Convert.ToDouble (this.userInputTemp.Text);

                string tempZ = (string)((ComboBoxItem)((ComboBox)this.TempZ).SelectedValue).Content;
                string tempNa = (string)((ComboBoxItem)((ComboBox)this.TempDo).SelectedValue).Content;
                this.wynikTemp.Text = Math.Round(przelicznik.przelicz(tempZ, tempNa, liczba), 1, MidpointRounding.ToEven).ToString();
            }
            return;
        }

        private void MasaCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.userInputMasa.Text != null && this.MasaZ.SelectedValue != null && this.MasaDo.SelectedValue != null)
            {
                Masa przelicznik = new Masa();
                double liczba = Convert.ToDouble(this.userInputMasa.Text);

                string masaZ = (string)((ComboBoxItem)((ComboBox)this.MasaZ).SelectedValue).Content;
                string masaDo = (string)((ComboBoxItem)((ComboBox)this.MasaDo).SelectedValue).Content;
                this.wynikMasa.Text = Math.Round(przelicznik.przelicz(masaZ, masaDo, liczba), 1, MidpointRounding.ToEven).ToString();
            }
            return;
        }
        private void PredkCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.userInputPredk.Text != null && this.PredkoscZ.SelectedValue != null && this.PredkoscDo.SelectedValue != null)
            {
                Prędkość przelicznik = new Prędkość();
                double liczba = Convert.ToDouble(this.userInputPredk.Text);

                string PredkoscZ = (string)((ComboBoxItem)((ComboBox)this.PredkoscZ).SelectedValue).Content;
                string PredkoscDo = (string)((ComboBoxItem)((ComboBox)this.PredkoscDo).SelectedValue).Content;

                this.wynikPredk.Text = Math.Round(przelicznik.przelicz(PredkoscZ, PredkoscDo, liczba), 1, MidpointRounding.ToEven).ToString();
            }
            return;
        }



        private void DlugCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.userInputDlug.Text != null && this.DlugoscZ.SelectedValue != null && this.DlugoscDo.SelectedValue != null)
            {
                Długości przelicznik = new Długości();
                double liczba = Convert.ToDouble(this.userInputDlug.Text);

                string DlugoscZ = (string)((ComboBoxItem)((ComboBox)this.DlugoscZ).SelectedValue).Content;
                string DlugoscDo = (string)((ComboBoxItem)((ComboBox)this.DlugoscDo).SelectedValue).Content;
                
                this.wynikDlug.Text = Math.Round(przelicznik.przelicz(DlugoscZ, DlugoscDo, liczba), 1,MidpointRounding.ToEven).ToString();
            }
            return;
        }
         private void Klikniecie(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
