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
using System.Text.RegularExpressions;
using ziecina_zad1;

namespace ziecinaUnitConverter.Desktop
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<IConverter> converters;
        public static int chosenConverter;
        public static bool queriedOnce = false;
        public static int currentPage = 0; //////////
        DataInserter dataInserter = new DataInserter();
        List<JIPP4> conversions;

        public string pageSwap()
        {
            using (KASETY_412_23Entities1 context = new KASETY_412_23Entities1())
            {
                string toReturn = "";
                int tmpCnt = 0;
                foreach (JIPP4 f in conversions)
                {
                    if (f.errorEncountered == false && tmpCnt < (20 * currentPage) && tmpCnt > ((currentPage * 20) - 20))
                    {
                        toReturn += (f.dateSent).Value.ToString("dd/MM/yyy") + ": " + f.Converter + " - " + f.valueBefore + " " + f.unitFrom + " to " + f.valueAfter + " " + f.unitTo + "\n";

                    }
                    tmpCnt += 1;
                }
                return toReturn;
            }
        }


        public MainWindow()
        {
            

            InitializeComponent();
            using (KASETY_412_23Entities1 context = new KASETY_412_23Entities1())
            {
                List<AppRatings> ratingsContainer;
                string queryTextn = "SELECT top 1 RatingId, RatingScore FROM AppRatings order by RatingId desc;";
                ratingsContainer = context.AppRatings.SqlQuery(queryTextn).ToList();
                int oldRating = ratingsContainer[0].RatingScore;
                RateButtons.RateValue = oldRating;
            }
            RateButtons.RateValueChanged += RateApp_RateValueChanged;
            ///////////////// PRZYKŁAD ZAPYTANIA /////////////////////////
            //////////////////////////////////////////////////////////////
            /* 
            using(KASETY_412_23Entities1 context = new KASETY_412_23Entities1()) 
            {
                List<JIPP4> conversions = context.JIPP4.ToList();
                foreach (JIPP4 e in conversions)
                {
                    blockResault.Text += (e.Converter) + "\n";
                }
            }
            */
            ///////////////////////////////////////////////////////////////
            converters = new List<IConverter>()
            {
                new ConvertTemperature(),
                new ConvertMass(),
                new ConvertLength(),
                new ConvertVolume()
            };
            for (int i = 0; i < converters.Count; i++)
            {
                listConverters.Items.Add(converters[i].Name);
                queryConverterPicker.Items.Add(converters[i].Name);
            }
            queryConverterPicker.Items.Add("Konwerter czasu");
        }

        private void textValues_KeyUp(object sender, KeyEventArgs e)
        {
            string input = textValues.Text;
            try
            {
                float whateva = Convert.ToSingle(input);
                float toDisplay = MainWindow.converters[chosenConverter].Convert(listStartUnit.SelectedItem.ToString(), listEndUnit.SelectedItem.ToString(), input);
                string toDisplayStr = toDisplay.ToString();
                blockResault.Text = toDisplayStr;
                dataInserter.InsertData(MainWindow.converters[chosenConverter].Name, listStartUnit.SelectedItem.ToString(), listEndUnit.SelectedItem.ToString(), input, toDisplayStr, false);
            }
            catch
            {
                blockResault.Text = "Niepoprawne dane";
            }
        }

        private void listConverters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.chosenConverter = listConverters.SelectedIndex;
            listStartUnit.ItemsSource = MainWindow.converters[chosenConverter].Units;
            listEndUnit.ItemsSource = MainWindow.converters[chosenConverter].Units;
        }

        private void textValues_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void text12h_KeyUp(object sender, KeyEventArgs e)
        {
            ziecinaUnitConverter.Logic.ConvertHour convH = new ziecinaUnitConverter.Logic.ConvertHour();
            if (radioAM.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "AM");
                blockResaultHour.Text = newHour;
                string newHour2 = newHour;
                int hour = Convert.ToInt32(newHour[0]) * 10 + Convert.ToInt32(newHour[1]);
                RotateTransform rotateTransform1 = new RotateTransform(hour * 30);
                handHour.RenderTransform = rotateTransform1;
                RotateTransform rotateTransform2 = new RotateTransform(0);
                handSecond.RenderTransform = rotateTransform2;
                ((Storyboard)Resources["clockMovingSecond"]).Begin();

                int minute = Convert.ToInt32(newHour2[3]) * 10 + Convert.ToInt32(newHour2[4]);
                RotateTransform rotateTransform3 = new RotateTransform(((minute - 528) * 6));
                handMinute.RenderTransform = rotateTransform3;
                //blockResaultHour.Text = minute.ToString();
                bool isError = false;
                if (newHour == "Niepoprawny format daty")
                {
                    newHour = null;
                    isError = true;
                }
                string new12h = Regex.Replace(text12h.Text, @"\r\n?|\n", "");
                dataInserter.InsertData("Konwerter czasu", "AM/PM", "24h", new12h, newHour, isError);



            }
            else if (radioPM.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "PM");
                blockResaultHour.Text = newHour;
                string newHour2 = newHour;
                int hour = Convert.ToInt32(newHour[0]) * 10 + Convert.ToInt32(newHour[1]);
                RotateTransform rotateTransform1 = new RotateTransform(hour * 30);
                handHour.RenderTransform = rotateTransform1;
                RotateTransform rotateTransform2 = new RotateTransform(0);
                handSecond.RenderTransform = rotateTransform2;
                ((Storyboard)Resources["clockMovingSecond"]).Begin();

                int minute = Convert.ToInt32(newHour2[3]) * 10 + Convert.ToInt32(newHour2[4]);
                RotateTransform rotateTransform3 = new RotateTransform(((minute - 528) * 6));
                handMinute.RenderTransform = rotateTransform3;
                //blockResaultHour.Text = minute.ToString();
                bool isError = false;
                if (newHour == "Niepoprawny format daty")
                {
                    newHour = null;
                    isError = true;
                }
                string new12h = Regex.Replace(text12h.Text, @"\r\n?|\n", "");
                dataInserter.InsertData("Konwerter czasu", "AM/PM", "24h", new12h, newHour, isError);
            }
            else if (radio24h.IsChecked == true)
            {
                string newHour = convH.Convert(text12h.Text, "24h");
                blockResaultHour.Text = newHour;
                newHour = convH.Convert(text12h.Text, "PM");
                //blockResaultHour.Text = newHour;
                string newHour2 = newHour;
                ///////////////////////////////////////////////////////////
                int hour = Convert.ToInt32(newHour[0]) * 10 + Convert.ToInt32(newHour[1]);
                RotateTransform rotateTransform1 = new RotateTransform(hour * 30);
                handHour.RenderTransform = rotateTransform1;
                RotateTransform rotateTransform2 = new RotateTransform(0);
                handSecond.RenderTransform = rotateTransform2;
                ((Storyboard)Resources["clockMovingSecond"]).Begin();

                int minute = Convert.ToInt32(newHour2[3]) * 10 + Convert.ToInt32(newHour2[4]);
                RotateTransform rotateTransform3 = new RotateTransform(((minute - 528) * 6));
                handMinute.RenderTransform = rotateTransform3;
                //blockResaultHour.Text = minute.ToString();
                bool isError = false;
                if (newHour == "Niepoprawny format daty")
                {
                    newHour = null;
                    isError = true;
                }
                string new12h = Regex.Replace(text12h.Text, @"\r\n?|\n", "");
                dataInserter.InsertData("Konwerter czasu", "24h", "AM/PM", new12h, newHour, isError);
            }
            else
            {
                blockResaultHour.Text = "Proszę wybrać startowy format";

            }
        }

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            using (KASETY_412_23Entities1 context = new KASETY_412_23Entities1())
            {
                if (queryConverterPicker.SelectedItem != null && dateFromBox.SelectedDate != null && dateToBox.SelectedDate != null)
                {
                    string dateFrom = "'" + dateFromBox.SelectedDate.Value.ToString("yyy.MM.dd") + "'";
                    string dateTo = "'" + dateToBox.SelectedDate.Value.ToString("yyy.MM.dd") + "'";
                    string convPick = "'" + queryConverterPicker.SelectedItem.ToString() + "'";
                    string queryText1 = "SELECT * FROM JIPP4 WHERE Converter LIKE " + convPick + " AND dateSent >= " + dateFrom + " AND dateSent <= " + dateTo + ";";
                    conversions = (context.JIPP4.SqlQuery(queryText1)).ToList();
                    textBlockResaults.Text = "";
                    int tmpCnt = 0;
                    foreach (JIPP4 f in conversions)
                    {
                        if (f.errorEncountered == false && tmpCnt < 20)
                        {
                            textBlockResaults.Text += (f.dateSent).Value.ToString("dd/MM/yyy") + ": " + f.Converter + " - " + f.valueBefore + " " + f.unitFrom + " to " + f.valueAfter + " " + f.unitTo + "\n";
                            var resaults = context.JIPP4.Add(f);
                            tmpCnt += 1;
                        }
                    }
                    queriedOnce = true;
                    currentPage = 1;
                    var results = context.JIPP4.AsQueryable()
                    .GroupBy(x => new { x.Converter, x.unitFrom, x.unitTo })
                    .Select(x => new { x.Key.Converter, x.Key.unitFrom, x.Key.unitTo, Count = x.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(3);
                    //////////TODO todo
                    var abc = results.ToList();
                    top3Resaults.Text = "";
                    for (int i = 0; i < 3; i++)
                    {
                        top3Resaults.Text += abc.ElementAt(i).Count + ": ";
                        top3Resaults.Text += abc.ElementAt(i).unitFrom + " na ";
                        top3Resaults.Text += abc.ElementAt(i).unitTo + "\n";

                    }
                }
                else
                {
                    textBlockResaults.Text = "Niepoprawne dane";
                }
            }
        }

        private void buttonPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (queriedOnce == true && currentPage >= 2)
            {
                currentPage -= 1;
                textBlockResaults.Text = pageSwap();
            }
        }

        private void buttonNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (queriedOnce == true)
            {
                currentPage += 1;
                textBlockResaults.Text = pageSwap();
            }
        }
        private void RateApp_RateValueChanged(int value)
        {
            int assdaync = value;
            //zapis do DB

        }
    }
}
