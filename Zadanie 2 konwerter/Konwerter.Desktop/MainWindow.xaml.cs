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
using Konwerter.Logic;

namespace Konwerter.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<IKonwertery> converters = new List<IKonwertery>()
            {
                new Konwerter_Mas(),
                new Konwerter_Mocy(),
                new Konwerter_Odleglosci(),
                new Konwerter_Temperatur()
            };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string init_value;
            double value;
            //POCZĄTEK SEKCJI TEMPERATUR//
            if (TempTextBox_C.IsKeyboardFocusWithin)
            {               
                init_value = TempTextBox_C.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");                   
                }
                TempTextBox_F.Text = converters[3].Konwertuj("C", "F", value).ToString();
                TempTextBox_K.Text = converters[3].Konwertuj("C", "K", value).ToString();
            }
            if (TempTextBox_F.IsKeyboardFocusWithin)
            {                
                init_value = TempTextBox_F.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");                    
                }
                TempTextBox_C.Text = converters[3].Konwertuj("F", "C", value).ToString();
                TempTextBox_K.Text = converters[3].Konwertuj("F", "K", value).ToString();
            }
            if (TempTextBox_K.IsKeyboardFocusWithin)
            {             
                init_value = TempTextBox_K.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");                    
                }
                TempTextBox_C.Text = converters[3].Konwertuj("K", "C", value).ToString();
                TempTextBox_F.Text = converters[3].Konwertuj("K", "F", value).ToString();
            }
            //KONIEC SEKCJI TEMPERATUR//
            //POCZĄTEK SEKCJI MAS//
            if (MasyTextBox_Kg.IsKeyboardFocusWithin)
            {
                init_value = MasyTextBox_Kg.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MasyTextBox_F.Text = converters[0].Konwertuj("Kg", "F", value).ToString();
                MasyTextBox_dkg.Text = converters[0].Konwertuj("Kg", "dkg", value).ToString();
            }
            if (MasyTextBox_F.IsKeyboardFocusWithin)
            {
                init_value = MasyTextBox_F.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MasyTextBox_Kg.Text = converters[0].Konwertuj("F", "Kg", value).ToString();
                MasyTextBox_dkg.Text = converters[0].Konwertuj("F", "dkg", value).ToString();
            }
            if (MasyTextBox_dkg.IsKeyboardFocusWithin)
            {
                init_value = MasyTextBox_dkg.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MasyTextBox_Kg.Text = converters[0].Konwertuj("dkg", "Kg", value).ToString();
                MasyTextBox_F.Text = converters[0].Konwertuj("dkg", "F", value).ToString();
            }
            //KONIEC SEKCJI MAS//
            //POCZĄTEK SEKCJI MOCY//
            if (MocTextBox_W.IsKeyboardFocusWithin)
            {
                init_value = MocTextBox_W.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MocTextBox_kW.Text = converters[1].Konwertuj("W", "kW", value).ToString();
                MocTextBox_KM.Text = converters[1].Konwertuj("W", "KM", value).ToString();
            }
            if (MocTextBox_kW.IsKeyboardFocusWithin)
            {
                init_value = MocTextBox_kW.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MocTextBox_W.Text = converters[1].Konwertuj("kW", "W", value).ToString();
                MocTextBox_KM.Text = converters[1].Konwertuj("kW", "KM", value).ToString();
            }
            if (MocTextBox_KM.IsKeyboardFocusWithin)
            {
                init_value = MocTextBox_KM.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                MocTextBox_kW.Text = converters[1].Konwertuj("KM", "kW", value).ToString();
                MocTextBox_W.Text = converters[1].Konwertuj("KM", "W", value).ToString();
            }
            //KONIEC SEKCJI MOCY//
            //POCZĄTEK SEKCJI ODLEGŁOŚCI//
            if (OdlegloscTextBox_Km.IsKeyboardFocusWithin)
            {
                init_value = OdlegloscTextBox_Km.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                OdlegloscTextBox_Mi.Text = converters[2].Konwertuj("Km", "Mi", value).ToString();
                OdlegloscTextBox_ft.Text = converters[2].Konwertuj("Km", "ft", value).ToString();
            }
            if (OdlegloscTextBox_Mi.IsKeyboardFocusWithin)
            {
                init_value = OdlegloscTextBox_Mi.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                OdlegloscTextBox_Km.Text = converters[2].Konwertuj("Mi", "Km", value).ToString();
                OdlegloscTextBox_ft.Text = converters[2].Konwertuj("Mi", "ft", value).ToString();
            }
            if (OdlegloscTextBox_ft.IsKeyboardFocusWithin)
            {
                init_value = OdlegloscTextBox_ft.Text;
                if (double.TryParse(init_value, out value) == false)
                {
                    MessageBox.Show("Podaj poprawną wartość");
                }
                OdlegloscTextBox_Km.Text = converters[2].Konwertuj("ft", "Km", value).ToString();
                OdlegloscTextBox_Mi.Text = converters[2].Konwertuj("ft", "Mi", value).ToString();
            }
            //KONIEC SEKCJI ODLEGŁOSĆI//
        }
    }
}

