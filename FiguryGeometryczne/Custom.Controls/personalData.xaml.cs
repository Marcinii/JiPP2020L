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

namespace Custom.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy Ocena.xaml
    /// </summary>
    public partial class personalData : UserControl
    {
        public personalData()
        {
            InitializeComponent();
        }


        public event EventHandler<personalDataEventArgs> personalDataValueChanged;
        
        
        private string _FirstNameValue;
        private string _LastNameValue;
        private string _AgeValue;
        public string FirstNameValue { get { return _FirstNameValue; } set { _FirstNameValue = value; } }
        public string LastNameValue { get { return _LastNameValue; } set { _LastNameValue = value; } }
        public string AgeValue { get { return _AgeValue; } set { _AgeValue = value; } }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AgeValue = AgeTextBox.Text;
            FirstNameValue = FirstNameTextBox.Text;
            LastNameValue = LastNameTextBox.Text;
            personalDataValueChanged(this, new personalDataEventArgs() { FirstName = FirstNameValue, LastName = LastNameValue, Age = AgeValue });
        }

        public class personalDataEventArgs : EventArgs
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set; }
        }

        }
    }

