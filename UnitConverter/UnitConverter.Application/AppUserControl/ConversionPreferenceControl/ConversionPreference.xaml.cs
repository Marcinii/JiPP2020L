using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UnitConverter.Application.AppUserControl.ConversionPreferenceControl
{
    /// <summary>
    /// Interaction logic for ConversionPreference.xaml
    /// </summary>
    /// <param name="height">
    ///     Wysokość kontrolki
    /// </param>
    /// <param name="labelText">
    ///     Wyświetlany tekst w etykiecie
    /// </param>
    /// <param name="arrowEnabled">
    ///     Pole, które posłuży do zmiany kursora myszki dla etykiety.
    ///     Dla wartości 'true' kursor zmieni się na Hand. 
    ///     W rzeciwnym wypadku kursor zmieni się na domyslny dla etykiety
    /// </param>
    /// <param name="disabled">
    ///     Pole decydujące o tym, czy kontrolka jest aktywna
    /// </param>
    /// <param name="content">
    ///     Pole przechowujące definicję kontrolki, która będzie zagnieżdżona w naszą kontrolkę
    /// </param>
    /// <param name="contentHeight">
    ///     Wysokość zagnieżdżonej zawartości
    /// </param>
    public partial class ConversionPreference : UserControl
    {
        public event EventHandler labelClick;



        public int height
        {
            get { return (int)GetValue(heightProperty); }
            set { SetValue(heightProperty, value); }
        }

        public static readonly DependencyProperty heightProperty =
            DependencyProperty.Register("height", typeof(int), typeof(ConversionPreference), new PropertyMetadata(50));






        public string labelText
        {
            get { return (string)GetValue(labelTextProperty); }
            set { SetValue(labelTextProperty, value); }
        }

        public static readonly DependencyProperty labelTextProperty =
            DependencyProperty.Register("labelText", typeof(string), typeof(ConversionPreference), new PropertyMetadata("Default value"));






        public bool arrowEnabled
        {
            get { return (bool)GetValue(arrowEnabledProperty); }
            set { SetValue(arrowEnabledProperty, value); }
        }

        public static readonly DependencyProperty arrowEnabledProperty =
            DependencyProperty.Register("arrowEnabled", typeof(bool), typeof(ConversionPreference), new PropertyMetadata(false));






        public bool disabled
        {
            get { return (bool)GetValue(disabledProperty); }
            set { 
                SetValue(disabledProperty, value);
                ((UIElement)this.content).IsEnabled = !value;
                this.preferenceLabel.Cursor = !value && arrowEnabled ? Cursors.Hand : Cursors.Arrow;
            }
        }

        public static readonly DependencyProperty disabledProperty =
            DependencyProperty.Register("disabled", typeof(bool), typeof(ConversionPreference), new PropertyMetadata(false));






        public object content
        {
            get { return (object)GetValue(contentProperty); }
            set { SetValue(contentProperty, value); }
        }

        public static readonly DependencyProperty contentProperty =
            DependencyProperty.Register("content", typeof(object), typeof(ConversionPreference), new FrameworkPropertyMetadata(null));






        public int contentHeight
        {
            get { return (int)GetValue(contentHeightProperty); }
            set { 
                SetValue(contentHeightProperty, value);
                ((Control)this.content).Height = value;
            }
        }

        public static readonly DependencyProperty contentHeightProperty =
            DependencyProperty.Register("contentHeight", typeof(int), typeof(ConversionPreference), new PropertyMetadata(31));








        public ConversionPreference()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public override void OnApplyTemplate()
        {
            this.contentHeight = 31;
        }



        /// <summary>
        /// Metoda, która wywołuje się w momencie kliknięcia na etykietę <see cref="preferenceLabel"/>.
        /// Metoda ta wywołuje zdarzenie <see cref="labelClick"/>, które będzie można przechwycić.
        /// To zdarzenie będzie się wywoływało w momncie kliknięcia na etykietę.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preferenceLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => labelClick?.Invoke(sender, e);
    }
}
