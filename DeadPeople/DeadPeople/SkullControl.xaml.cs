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

namespace DeadPeople
{
    /// <summary>
    /// Interaction logic for SkullControl.xaml
    /// </summary>
    public partial class SkullControl : UserControl
    {
        public object Skull
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(SkullControl), new PropertyMetadata("czaszka ->（ •...•）"));


        public SkullControl()
        {
            InitializeComponent();
        }

        private void Skull_Click(object sender, RoutedEventArgs e)
        {
            if(skullGrid.Visibility == Visibility.Visible)
            {
                contentGrid.Visibility = Visibility.Visible;
                skullGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                contentGrid.Visibility = Visibility.Collapsed;
                skullGrid.Visibility = Visibility.Visible;

            }
        }
    }
}
