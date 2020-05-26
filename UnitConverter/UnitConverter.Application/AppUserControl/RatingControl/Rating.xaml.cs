using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UnitConverter.Application.Command;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Application.AppUserControl.RatingControl
{
    /// <summary>
    /// Interaction logic for Rating.xaml
    /// </summary>
    public partial class Rating : UserControl
    {
        public ButtonCommand ratingButtonCommand { get; private set; }
        private int highlightedValue = 0;

        public CustomInteger value { get; set; } = 0;
        public event RatingEventHandler onChange;

        public Rating()
        {
            this.ratingButtonCommand = new ButtonCommand(
                x => setValue()
            );

            InitializeComponent();
            
            this.DataContext = this;
        }



        /// <summary>
        /// Metoda, która ustawia wartość oceny według klikniętego przycisku
        /// </summary>
        private void setValue()
        {
            for(int i = 0; i < 5; i++)
            {
                ((Button)this.ratingGrid.Children[i]).BorderBrush = Brushes.Black;
                ((Button)this.ratingGrid.Children[i]).Background = Brushes.Transparent;
            }

            this.value = highlightedValue;
            for (int i = 0; i < this.highlightedValue; i++)
            {
                ((Button)this.ratingGrid.Children[i]).BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff8c00");
                ((Button)this.ratingGrid.Children[i]).Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#ff8c00");
            }

            this.onChange?.Invoke(this, new RatingEventArgs(this.value));
        }



        /// <summary>
        /// Metoda, która ma za zadanie podświetlić gwiazdki, które zostały najechane myszką.
        /// Metoda podświetla wszystkie gwiazdki począwszy od pierwszej gwiazdki do tej, na którą użytkowuk najechał.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void highlightStars(object sender, MouseEventArgs e)
        {
            for(int i = 0; i <= this.ratingGrid.Children.IndexOf((Button)sender); i++)
            {
                Button button = (Button)this.ratingGrid.Children[i];

                if(this.value < i + 1)
                    button.BorderBrush = (SolidColorBrush)new BrushConverter().ConvertFrom("#ffdc5c");
            }

            this.highlightedValue = this.ratingGrid.Children.IndexOf((Button)sender) + 1;
        }



        /// <summary>
        /// Metoda restartująca podświetlenie gwiazdek. Wywoływana jest w momencie, gdy użytkownik przemieści kursor poza obręb gwiazdki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void resetHighlghting(object sender, MouseEventArgs args)
        {
            for (int i = 0; i <= this.ratingGrid.Children.IndexOf((Button)sender); i++)
            {
                Button button = ((Button)this.ratingGrid.Children[i]);

                if(button.Background == Brushes.Transparent)
                    button.BorderBrush = Brushes.Black;
            }

            this.highlightedValue = 0;
        }
    }
}
