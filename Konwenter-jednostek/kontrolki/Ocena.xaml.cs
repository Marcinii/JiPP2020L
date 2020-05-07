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

namespace kontrolki
{
    /// <summary>
    /// Logika interakcji dla klasy Ocena.xaml
    /// </summary>
    public partial class Ocena : UserControl
    {
        public Ocena()
        {
            InitializeComponent();
        }
        

        public event EventHandler<OcenaEventArgs> OcenaValueChanged;
        bool on = true;
        private int _ocenaValue;
        public int OcenaValue
        {
            get { return _ocenaValue; }

            set
            {
                _ocenaValue = value;

                if (_ocenaValue < 0)
                {
                    _ocenaValue = 1;
                }
                else if (_ocenaValue > 5)
                {
                    _ocenaValue = 5;
                }
                else _ocenaValue = value;
                on = false;

                foreach (var b in elipseGrid.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.White);
                }
               
                for (int i = 1; i <= _ocenaValue; i++)
                {
                    ((Button)elipseGrid.Children[OcenaValue -i]).Background = new SolidColorBrush(Colors.Green);
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            foreach (var b in elipseGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            ((Button)sender).Background = new SolidColorBrush(Colors.Green); //ff008000

           

            OcenaValue = elipseGrid.Children.IndexOf((Button)sender) + 1;
            OcenaValueChanged(this, new OcenaEventArgs() { Value = OcenaValue });
        }
           
        public class OcenaEventArgs : EventArgs
        {
            public int Value { get; set; }
        }
        

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {

             foreach (var b in elipseGrid.Children)
             {
                 ((Button)b).Background = new SolidColorBrush(Colors.White);
             }

             for (int i = 1; i <= elipseGrid.Children.IndexOf((Button)sender) + 1; i++)
             {
                 ((Button)elipseGrid.Children[(elipseGrid.Children.IndexOf((Button)sender) + 1) - i]).Background = new SolidColorBrush(Colors.Green);
             }
             on = true;
             
            
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            if (on)
            {
                foreach (var b in elipseGrid.Children)
                {
                    ((Button)b).Background = new SolidColorBrush(Colors.White);
                }
                
            }
          
           
        }
    }
}
