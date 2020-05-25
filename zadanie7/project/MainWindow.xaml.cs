using logic;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Iumowy> umowy = new List<Iumowy>()
        {
                new u_oprace(),
                new u_dzielo(),
                new u_zlecenie()
        };
        int from_to = 0; //this define how to count. 0->brutto-netto, 1->netto-brutto
        bool checked_or_no = false; //define checbox 26years
        int records_to_download = 5;
        int records_to_skip = 0;
        public MainWindow()
        {
            InitializeComponent();

            List<string> name_umowy = new List<string>();
            foreach (Iumowy s in umowy)
            {
                name_umowy.Add(s.name);
            }
            umowa.ItemsSource = name_umowy;
            task_load_history();
        }

        private void change_brutto_netto(object sender, RoutedEventArgs e)
        {
            if (from_to == 0)
            {
                from_to++;
                from_label.Text = "Netto";
                to_label.Text = "Brutto";
            }
            else if(from_to == 1)
            {
                from_to--;
                from_label.Text = "Brutto";
                to_label.Text = "Netto";
            }
        }

        private void over26_Checked(object sender, RoutedEventArgs e)
        {
            checked_or_no = true;
        }

        private void over26_Unchecked(object sender, RoutedEventArgs e)
        {
            checked_or_no = false;
        }

        private void create_percent(Iumowy choosen)
        {
            double percent = parse.convert_decimal_to_double(choosen.show_percent(checked_or_no));
            var myRect1 = new System.Windows.Shapes.Rectangle();
            myRect1.Fill = System.Windows.Media.Brushes.LightGreen;
            myRect1.HorizontalAlignment = HorizontalAlignment.Left;
            myRect1.Height = 50;
            myRect1.Width = percent * 2;
            myRect1.Margin = new Thickness(400,-150,0,0);
            mygrid.Children.Add(myRect1);

            var myRect2 = new System.Windows.Shapes.Rectangle();
            myRect2.Fill = System.Windows.Media.Brushes.Red;
            myRect2.HorizontalAlignment = HorizontalAlignment.Left;
            myRect2.Height = 50;
            myRect2.Width = 200 - percent * 2;
            myRect2.Margin = new Thickness(400+myRect1.Width, -150, 0, 0);
            mygrid.Children.Add(myRect2);
            result_brutto.Text = "Brutto";
            result_netto.Text = "Netto";
            result_title.Text = "Procentowy rozkład kwoty netto:";
        }

        private void count(object sender, RoutedEventArgs e)
        {
            decimal value_to_count = parse.convert_string_to_decimal(value.Text);
            decimal result_to_show;
            Iumowy choosen = umowy.Find(search_umowa => search_umowa.name.Equals(umowa.SelectedItem));
            if (from_to == 0)
            {
                result_to_show = choosen.count_brutto_netto(value.Text, checked_or_no);
                result.Text = result_to_show.ToString();
            }
            else if (from_to == 1)
            {
                result_to_show = choosen.count_netto_brutto(value.Text, checked_or_no);
                result.Text = result_to_show.ToString();
            }
            db_operations.insert_data(choosen.name, value.Text, result.Text);
            create_percent(choosen);
            ((Storyboard)Resources["change_color"]).Begin();
        }

        private void start_load_screen()
        {
            load_animation.Visibility = load_text.Visibility = load.Visibility = Visibility.Visible;
            
            var animation = new DoubleAnimation(0, 360, new Duration(TimeSpan.FromSeconds(2)));
            animation.RepeatBehavior = RepeatBehavior.Forever;
            var rotate = new RotateTransform();
            load_animation.RenderTransform = rotate;
            load_animation.RenderTransformOrigin = new Point(0.5, 0.5);
            rotate.BeginAnimation(RotateTransform.AngleProperty, animation);
        }

        private void stop_load_screen()
        {
            load_animation.Visibility = load_text.Visibility = load.Visibility = Visibility.Hidden;
            
            var rotate = new RotateTransform();
            load_animation.RenderTransform = rotate;
            rotate.BeginAnimation(RotateTransform.AngleProperty, null);
        }

        private void task_load_history()
        {
            start_load_screen();
            Task download = new Task(() => load_history());
            download.Start();
        }

        private void load_history()
        {
            Task.Delay(5000).Wait();
            List<history> records = db_operations.download_data(records_to_skip, records_to_download);
            Dispatcher.Invoke(() => datagrid_history.ItemsSource = records);
            Dispatcher.Invoke(() => stop_load_screen());
        }

        private void next(object sender, RoutedEventArgs e)
        {
            records_to_skip += 5;
            task_load_history();
        }

        private void previous(object sender, RoutedEventArgs e)
        {
            records_to_skip -= 5;
            task_load_history();
        }

        private void refresh_history(object sender, RoutedEventArgs e)
        {
            task_load_history();
        }
    }
}
