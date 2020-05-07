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
using System.Data;
using unitconverter.logic;
using UnitConverter.Desktop;

namespace unitconverter.desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> unit_list = new List<string>() { };
        List<Iconverter> converters = new List<Iconverter>()
        {
                new c_lenght(),
                new c_temperature(),
                new c_weight(),
                new c_capacity(),
                new c_time()
        };
        int choosen_converter;
        int choosen_f_converter = 0;
        DateTime? date_from;
        DateTime? date_to;
        int from_lp = 0;
        int how_much_take_lp = 20;

        public MainWindow()
        {
            InitializeComponent();

            unit_from.ItemsSource = unit_list;
            unit_to.ItemsSource = unit_list;
            create_filters();
            List<rates> last_rate_record = db_operations.download_last_rate();
            int last_rate = 0;
            foreach (rates r in last_rate_record)
            {
                last_rate = r.rate;
            }
            rate.rate_value = last_rate;

            countcommand = new RelayCommand(obj => count(), 
                obj => unit_from.SelectedItem != null && unit_to.SelectedItem != null && string.IsNullOrEmpty(value.Text) != true);
            button_count.Command = countcommand;
            
            filtercommand = new RelayCommand(obj => filter());
            button_filter.Command = filtercommand;

            previouscommand = new RelayCommand(obj => previous(), obj => from_lp != 0);
            button_previous.Command = previouscommand;

            nextcommand = new RelayCommand(obj => next());
            button_next.Command = nextcommand;

        }

        private void F_converter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected_f_converter = f_converter.SelectedItem.ToString();
            int index_from_list = 1;
            foreach (Iconverter converter in converters)
            {   
                if (converter.name == selected_f_converter)
                {
                    choosen_f_converter = index_from_list;
                }
                index_from_list++;
            }
            create_datatable(choosen_f_converter, date_from, date_to, from_lp, how_much_take_lp);
        }

        private void create_filters()
        {
            List<string> f_converters = new List<string>() { };
            f_converters.Add("Wszystko");
            foreach (Iconverter converter in converters)
            {
                f_converters.Add(converter.name);
            }
            f_converter.ItemsSource = f_converters;
            f_date_from.Text = "Data od - rrrr-mm-dd";
            f_date_to.Text = "Data do - rrrr-mm-dd";
        }
        private RelayCommand filtercommand;
        private void filter()
        {
            date_from = f_date_from.SelectedDate;
            date_to = f_date_to.SelectedDate;
            create_datatable(choosen_f_converter, date_from, date_to, from_lp, how_much_take_lp);
        }

        private void create_datatable(int f_converter, DateTime? f_date_from, DateTime? f_date_to, int from_lp, int how_much_take_lp)
        {
            List<conversions> data = db_operations.download_data(f_converter, f_date_from, f_date_to, from_lp, how_much_take_lp);
            DataTable stats = new DataTable();
            List<DataColumn> columns = new List<DataColumn>()
            {
                new DataColumn("Lp", typeof(string)),
                new DataColumn("Konwerter", typeof(string)),
                new DataColumn("Z (jednostki)", typeof(string)),
                new DataColumn("Do (jednostki)", typeof(string)),
                new DataColumn("Z (wartość)", typeof(string)),
                new DataColumn("Do (wartość)", typeof(string)),
                new DataColumn("Kiedy", typeof(DateTime)),
            };
            foreach(DataColumn c in columns)
            {
                stats.Columns.Add(c);
            }
            int cout = 1;
            foreach(conversions c in data)
            {
                DataRow row = stats.NewRow();
                row[0] = cout.ToString();
                row[1] = converters[c.converter-1].name;
                row[2] = c.units_from;
                row[3] = c.units_to;
                row[4] = c.value_from;
                row[5] = c.value_to;
                row[6] = c.conversion_date;
                stats.Rows.Add(row);
                cout++;
            }
            stats_datatable.ItemsSource = stats.DefaultView;
            string rank_show = db_operations.make_rank(data);
            rank.Text = "Najczęściej: " + rank_show;
        }



        private void Stats_datatable_Loaded(object sender, RoutedEventArgs e)
        {
           create_datatable(choosen_f_converter, date_from, date_to, from_lp, how_much_take_lp);
        }
        private RelayCommand previouscommand;
        private void previous()
        {
            if (from_lp > 0)
            {
                from_lp -= 20;
                create_datatable(choosen_f_converter, date_from, date_to, from_lp, how_much_take_lp);
            }
        }
        private RelayCommand nextcommand;
        private void next()
        {
            from_lp += 20;
            create_datatable(choosen_f_converter, date_from, date_to, from_lp, how_much_take_lp);
        }

        private List<string> choose_units()
        {
            List<string> list = new List<string>() { };
            return list;
        }

        private void create_objects(int choosen_c)
        {
            unit_from.ItemsSource = unit_list;
            unit_to.ItemsSource = unit_list;
            unit_from.SelectedIndex = 0;
            unit_to.SelectedIndex = 0;
            choosen_converter = choosen_c;
        }

        private void lenght_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_lenght().units_names;
            create_objects(0);
        }
        private void temperature_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_temperature().units_names;
            create_objects(1);
        }
        private void weight_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_weight().units_names;
            create_objects(2);
        }
        private void capacity_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_capacity().units_names;
            create_objects(3);
        }
        private void time_checked(object sender, RoutedEventArgs e)
        {
            unit_list = new c_time().units_names;
            create_objects(4);
        }
        private RelayCommand countcommand;
        private void count(/*object sender, RoutedEventArgs e*/)
        {
            string from = unit_from.SelectedItem.ToString();
            string to = unit_to.SelectedItem.ToString();
            string value_to_convert = value.Text;
            bool should_use_custom_interpreter = false;
            decimal converted_value = parse.convert_string_to_decimal(value_to_convert);
            if (converted_value == 0)
            {
                List<string[]> data_arrays = new List<string[]>(); //list of arrays to custom convert, null arrays are necessery to keep this in right order
                data_arrays.Add(new string[0] { });
                data_arrays.Add(new string[0] { });
                data_arrays.Add(new string[0] { });
                data_arrays.Add(new string[0] { });
                data_arrays.Add(new string[2] { value_to_convert, from });
                converted_value = converters[choosen_converter].custom_convert(data_arrays[choosen_converter]);
                if (converted_value == 0) {MessageBox.Show("Podaj prawidłową wartość!"); } else { should_use_custom_interpreter = true; }
            }
            decimal conversion_result = converters[choosen_converter].operation(from, to, converted_value);
            if (conversion_result == 0) { MessageBox.Show("Podaj prawidłową wartość!"); }
            if (should_use_custom_interpreter) {
                string custom_conversion_result = converters[choosen_converter].custom_result_interpreter(conversion_result);
                result.Inlines.Add(new Run(custom_conversion_result));
                db_operations.insert_data(choosen_converter+1, from, to, value_to_convert, custom_conversion_result);
            }
            else
            {
                result.Inlines.Add(new Run(conversion_result + " "));
                db_operations.insert_data(choosen_converter+1, from, to, value_to_convert, conversion_result.ToString());
            }   
            if(choosen_converter == 4)
            {
                 int int_value = parse.convert_decimal_to_int(conversion_result); //separate numbers to make operations on them
                 int from_system = int_value / 100000;
                 int hour = (int_value / 1000) - (from_system * 100); 
                 int minute = (int_value / 10) - (from_system * 10000 + hour * 100);
                 if (hour > 12) { hour -= 12; }
                 double minute_angle = minute * 6; 
                 double hour_angle = 30 * hour + 0.5 * minute;

                //animation for minutes
                var minute_animation = new DoubleAnimation(0, minute_angle, new Duration(TimeSpan.FromSeconds(2)));
                var minute_rotate = new RotateTransform();
                xaml_minute.RenderTransform = minute_rotate;
                xaml_minute.RenderTransformOrigin = new Point(0.5, 1);
                minute_rotate.BeginAnimation(RotateTransform.AngleProperty, minute_animation);
                //

                //animation for hours
                var hour_animation = new DoubleAnimation(0, hour_angle, new Duration(TimeSpan.FromSeconds(2)));
                var hour_rotate = new RotateTransform();
                xaml_hour.RenderTransform = hour_rotate;
                xaml_hour.RenderTransformOrigin = new Point(0.5, 1);
                hour_rotate.BeginAnimation(RotateTransform.AngleProperty, hour_animation);
                //

            }
        }

        private void Rate_rate_value_changed(object sender, User_controls.rate_app.rate_event_args e)
        {
            db_operations.insert_rate(e.value);
        }
    }
}
