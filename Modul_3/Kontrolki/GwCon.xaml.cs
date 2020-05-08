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
    /// <summary>
    /// Logika interakcji dla klasy GwCon.xaml
    /// </summary>
    /// 

    
    public partial class GwCon : UserControl
    {
        public GwCon()
        {
            InitializeComponent();
        }
        private int _rateValue = 0;
        public event RateDelegate RataVAlueChange;
        public int RateValue
        {
            get { return _rateValue; }
            
            set {
                 _rateValue = value;

                Sprw();
                if(RataVAlueChange !=null)
                RataVAlueChange(_rateValue);
            }
        }
        private void Sprw()
        {
            if(RateValue > 5&&RateValue<0)
            {
                Wynik.Text = "Zła ocena";
            }
            else
            {
                UpdateButtons();
                Wynik.Text = "Dobra ocena";
            }
        }
        private void UpdateButtons()
        {
            foreach(var b in StartG.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }

       

          for(int i =0;i<_rateValue;i++)
            {
                ((Button)StartG.Children[i]).Background = new SolidColorBrush(Colors.Gold);
            }
          
        }
        private void reset()
        {
            foreach (var b in StartG.Children)
            {
                ((Button)b).Background = new SolidColorBrush(Colors.White);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
       if(_rateValue== StartG.Children.IndexOf((Button)sender) + 1)
            {
                RateValue = 0;
            }
       else
            RateValue = StartG.Children.IndexOf((Button)sender) + 1;
        }
        public delegate void RateDelegate(int value);
    }
   

}
