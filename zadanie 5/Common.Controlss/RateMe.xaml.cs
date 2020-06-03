﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Common.Controlss
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

        public event RateDelegate RateValueChanged;
        public int RateValue
        {
            get { return _rateValue; }
            set { _rateValue = value;
                UpdateButtons();
                if (RateValueChanged != null)
                {
                    RateValueChanged(_rateValue);
                }

                RateValueChanged(_rateValue);
            }
        }
        private void UpdateButtons()

        {
            foreach(var b in ratesGrid.Children)
            {

                ((Button)b).Background = new SolidColorBrush(Colors.White);
            
            }
            if (_rateValue > 0)
            {
                ((Button)ratesGrid.Children[_rateValue]).Background = new SolidColorBrush(Colors.Blue);     
                    }
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RateValue = ratesGrid.Children.IndexOf((Button)sender);
        }
            public delegate void RateDelegate(int value);
        }
    }

