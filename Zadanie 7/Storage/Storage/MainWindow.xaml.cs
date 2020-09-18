using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace Storage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool gate = true;
        public MainWindow()
        {
            
            InitializeComponent();
            Home.Content = new HomePage();
            
        }

        private void allButton_Click(object sender, RoutedEventArgs e)
        {
            MenuControl(gate);
            
        }

        private void MenuControl(bool value)
        {
            SetGridColWidth(Menu, gate);
            
        }

       
       
        private void SetGridColWidth(ColumnDefinition column, bool show)
        {
            if (show)
            {
                column.Width = new GridLength(4, GridUnitType.Star);
                hamburgerMenu.Rotation = 90;
            }
            else
            {
                column.Width = new GridLength(0);
                hamburgerMenu.Rotation = 0;
            }
            gate = !gate;
        }

        private void settingsWheelButton_Click(object sender, RoutedEventArgs e)
        {
            MenuControl(gate = false);
        }

        private void AddToBaseButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Content = new AddToDatebasePage();
            MenuControl(gate = false);

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Content = new HomePage();
            MenuControl(gate = false);
            
        }

        private void ShowDatebaseButton_Click(object sender, RoutedEventArgs e)
        {
            Home.Content = new Basedase();
            MenuControl(gate = false);

        }
    }
}
