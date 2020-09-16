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

namespace Ksiegarnia.Loading
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class LoadingControl : UserControl
    {
        CancellationTokenSource Source = new CancellationTokenSource();
        CancellationToken Token;
        public LoadingControl()
        {
            InitializeComponent();            
        }


        public void Start()
        {
            this.Visibility = Visibility.Visible;
            Token = Source.Token;
            foreach (Ellipse dot in DotGrid.Children)
            {
                dot.Fill = new SolidColorBrush(Colors.White);
            }
            Task animation = Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    Dispatcher.Invoke(() =>
                    {
                        if (i == 6)
                        {
                            i = 0;
                            foreach (Ellipse dot in DotGrid.Children)
                            {
                                dot.Fill = new SolidColorBrush(Colors.White);
                            }
                        }
                        (DotGrid.Children[i] as Ellipse).Fill = new SolidColorBrush(Colors.Green);
                        i++;                        
                    });
                    await Task.Delay(300);
                }
            }, Token);
        }
        public void Stop()
        {
            this.Visibility = Visibility.Collapsed;
            Source.Cancel();
        }
    }
}
