using Reviewer.Logic;
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
using System.Threading;

namespace Reviewer.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RelayCommand FilterCommand;
        private RelayCommand NewCommand;
        private RelayCommand AddCommand;
        private RelayCommand CancelCommand;

        public MainWindow()
        {
            InitializeComponent();
            FilterType.ItemsSource = new List<String>()
            {
                new Book().Type,
                new Movie().Type,
                new Game().Type,
            };

            InputType.ItemsSource = new List<String>()
            {
                new Book().Type,
                new Movie().Type,
                new Game().Type,
            };
            InputType.SelectedIndex = 1;

            Filter();

            FilterCommand = new RelayCommand(obj => Filter());
            NewCommand = new RelayCommand(obj => NewReview());
            AddCommand = new RelayCommand(obj => AddReview());
            CancelCommand = new RelayCommand(obj => Cancel());

            AddReviewButton.Command = AddCommand;
            FilterButton.Command = FilterCommand;
            NewReviewButton.Command = NewCommand;
            CancelButton.Command = CancelCommand;
        }

        CancellationTokenSource tokenSource;
        private void Filter()
        {
            tokenSource = new CancellationTokenSource();
            Loader.Visibility = Visibility.Visible;

            string Filter = FilterType.Text;
            Task getData = new Task(() => RefreshDB(tokenSource.Token, Filter), tokenSource.Token);
            getData.Start();
        }

        protected void RefreshDB(CancellationToken token, string Filter)
        {
            for (int i = 0; i < 10; i++)
            {
                if (token.IsCancellationRequested) return;
                Task.Delay(1000).Wait();
            }

            FilterFromDB(Filter);
        }

        private void Cancel()
        {
            Loader.Visibility = Visibility.Hidden;
            tokenSource.Cancel();
        }


        protected void FilterFromDB(string Filter)
        {
            using (MediaReviewerEntities context = new MediaReviewerEntities())
            {
                List<Medium> MediaList = context.Media
                .Where(s => Filter.Length > 0 ? s.TYPE == Filter : true)
                .ToList();

                Dispatcher.Invoke(() =>
                {
                    ReviewList.ItemsSource = MediaList;
                    Loader.Visibility = Visibility.Hidden;
                });
            }


        }

        private void AddReview()
        {
            using (MediaReviewerEntities context = new MediaReviewerEntities())
            {
                var result = context.Media.FirstOrDefault(b => b.TITLE == InputTitle.Text);
                if (result != null)
                {
                    result.RELEASE_DATE = InputDate.Text;
                    result.DESCRIPTION = InputDesc.Text;
                    result.SCORE = InputScore.RatingVal.ToString();
                    result.TYPE = InputType.Text;
                }
                else
                {
                    Medium newMedia = new Medium()
                    {
                        TITLE = InputTitle.Text,
                        RELEASE_DATE = InputDate.Text,
                        DESCRIPTION = InputDesc.Text,
                        SCORE = InputScore.RatingVal.ToString(),
                        TYPE = InputType.Text

                    };
                    context.Media.Add(newMedia);
                }

                context.SaveChanges();
            }
        }

        private void NewReview()
        {
            InputTitle.Clear();
            InputType.SelectedIndex = 1;
            InputDate.Clear();
            InputDesc.Clear();
            InputScore.RatingVal = 0;
        }

        private void ReviewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReviewList.SelectedIndex > -1)
            {
                InputTitle.Text = ((Medium)ReviewList.SelectedItem).TITLE;
                InputDate.Text = ((Medium)ReviewList.SelectedItem).RELEASE_DATE;
                InputDesc.Text = ((Medium)ReviewList.SelectedItem).DESCRIPTION;
                InputType.Text = ((Medium)ReviewList.SelectedItem).TYPE;
                int value;
                int.TryParse(((Medium)ReviewList.SelectedItem).SCORE, out value);
                InputScore.RatingVal = value;
            }

        }
    }
}
