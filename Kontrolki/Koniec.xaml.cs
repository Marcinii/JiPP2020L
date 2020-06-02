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

namespace Kontrolki
{

    public partial class Koniec : UserControl
    {
        public Koniec()
        {
            InitializeComponent();
        }

        private void PrzyciskKoniec_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno zakończyć program?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }
    }
}
