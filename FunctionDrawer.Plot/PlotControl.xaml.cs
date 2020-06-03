using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PlotDrawer.Plot
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class PlotControl : UserControl
    {
        public PlotControl()
        {
            InitializeComponent();
            PlotLine.Stroke = Brushes.Black;
            PlotLine.StrokeThickness = 2;
            PlotCanvas.Children.Add(PlotLine);
        }
        private void OnLoad(object sender, EventArgs e)
        {
            CreateMesh();
        }
        private void CreateMesh()
        {
            Line lineX = new Line()
            {
                X1 = 0,
                X2 = PlotCanvas.ActualWidth,
                Y1 = PlotCanvas.ActualHeight / 2,
                Y2 = PlotCanvas.ActualHeight / 2,

                Stroke = Brushes.Red,
                StrokeThickness = 1
            };
            Line lineY = new Line()
            {
                X1 = PlotCanvas.ActualWidth / 2,
                X2 = PlotCanvas.ActualWidth / 2,
                Y1 = 0,
                Y2 = PlotCanvas.ActualHeight,

                Stroke = Brushes.Red,
                StrokeThickness = 1
            };
            PlotCanvas.Children.Add(lineX);
            PlotCanvas.Children.Add(lineY);
            //vertical
            for(double i = PlotCanvas.ActualWidth/2+10; i < PlotCanvas.ActualWidth; i+=10)
            {
                PlotCanvas.Children.Add(new Line()
                {
                    X1 = i,
                    X2 = i,
                    Y1 = 0,
                    Y2 = PlotCanvas.ActualHeight,
                    Stroke = Brushes.Black,
                    StrokeThickness = 0.5                    
                });
            }
            for (double i = PlotCanvas.ActualWidth / 2 - 10; i > 0; i -= 10)
            {
                PlotCanvas.Children.Add(new Line()
                {
                    X1 = i,
                    X2 = i,
                    Y1 = 0,
                    Y2 = PlotCanvas.ActualHeight,

                    Stroke = Brushes.Black,
                    StrokeThickness = 0.5

                });
            }
            //horizontal
            for (double i = PlotCanvas.ActualHeight/2+10; i < PlotCanvas.ActualHeight; i += 10)
            {
                PlotCanvas.Children.Add(new Line()
                {
                    X1 = 0,
                    X2 = PlotCanvas.ActualWidth,
                    Y1 = i,
                    Y2 = i,
                    Stroke = Brushes.Black,
                    StrokeThickness = 0.5
                });                
            }
            for (double i = PlotCanvas.ActualHeight / 2 - 10; i > 0; i -= 10)
            {
                PlotCanvas.Children.Add(new Line()
                {
                    X1 = 0,
                    X2 = PlotCanvas.ActualWidth,
                    Y1 = i,
                    Y2 = i,
                    Stroke = Brushes.Black,
                    StrokeThickness = 0.5
                });
            }
        }      
        private Polyline PlotLine = new Polyline();
        private List<Point> PlotPoints = new List<Point>();
        public void AddToThePlot(double x, double y)
        {
            PlotPoints.Add(new Point(x, y));
            PlotLine.Points.Add(new Point()
            {
                X = PlotCanvas.ActualWidth / 2 + x,
                Y = PlotCanvas.ActualHeight / 2 - y
            });
        }

        public Task AddToThePlotAsync(double x, double y)
        {
            return Task.Run(() =>
            {
                PlotPoints.Add(new Point(x, y));
                PlotLine.Points.Add(new Point()
                {
                    X = PlotCanvas.ActualWidth / 2 + x,
                    Y = PlotCanvas.ActualHeight / 2 - y
                });
            });           
        }

        public void ResetPlot()
        {
            PlotLine.Points.Clear();
        }
    }
}