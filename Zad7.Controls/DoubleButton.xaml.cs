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

namespace Zad7.Controls
{
    /// <summary>
    /// Interaction logic for DoubleButton.xaml
    /// </summary>
    public partial class DoubleButton : UserControl
    {
        public DoubleButton()
        {
            InitializeComponent();
        }


        public string SendButtonText
        {
            get
            {
                return Send.Content.ToString();
            }
            set
            {
                Send.Content = value;
            }

        }
        public string ClearButtonText
        {
            get
            {
                return Clear.Content.ToString();
            }
            set
            {
                Clear.Content = value;
            }

        }



        public event EventHandler SendButtonClick;
        public event EventHandler ClearButtonClick;

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SendButtonClick?.Invoke(this, e);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearButtonClick?.Invoke(this, e);
        }
    }
}
