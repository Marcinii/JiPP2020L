﻿using System;
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

namespace Common.Controls
{
    /// <summary>
    /// Interaction logic for RateMe.xaml
    /// </summary>
    public partial class RateMe : UserControl
    {
        public RateMe()
        {
            InitializeComponent();
        }

        private int _rateValue = 0;

        public event EventHandler<RateEventArgs> RateValueChanged;

        public int RateValue
        {
            get { return _rateValue; }
            set
            {
                // powinniśmy sprawdzać czy wartość jest poprawna (0-5)

                if (value < 0 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("value", "błędna wartość!!!!!");
                }

                _rateValue = value;

                UpdateButtons();

                if (RateValueChanged != null)
                {
                    RateValueChanged(this, new RateEventArgs() { Value = _rateValue });
                }
            }
        }

        private void UpdateButtons()
        {
            foreach (var b in ratesGrid.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

            if (_rateValue > 0)
            {
                //((Button)ratesGrid.Children[_rateValue - 1]).Background = new SolidColorBrush(Colors.Red);
                for (int t = 0; t < _rateValue; t++)
                {
                    ((Button)ratesGrid.Children[t]).Background = new SolidColorBrush(Colors.Red);
                }
                for (int s = _rateValue; s < 5; s++)
                {
                    ((Button)ratesGrid.Children[s]).Background = new SolidColorBrush(Colors.White);
                }
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RateValue = ratesGrid.Children.IndexOf((Button)sender) + 1;
        }
        public void Zeruj()
        {
            foreach (var element in ratesGrid.Children)
            {
                ((Button)element).Background = new SolidColorBrush(Colors.White);
            }
    }
    }
    public class RateEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
