using System;
using System.Collections.Generic;
using System.Globalization;
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
using Logic.Services;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataCapacityConvertingService _dataCapacityConvertingService;
        public MainWindow()
        {
            InitializeComponent();
            _dataCapacityConvertingService = new DataCapacityConvertingService();
        }

        public void BitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var value = BitsInput.Text;
                _dataCapacityConvertingService.Bits = int.Parse(value);
                KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString(CultureInfo.InvariantCulture);
                MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString(CultureInfo.InvariantCulture);
                BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString(CultureInfo.InvariantCulture);
                KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString(CultureInfo.InvariantCulture);
                MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString(CultureInfo.InvariantCulture);
            }
        }


        public void KilobitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = KilobitsInput.Text;
                _dataCapacityConvertingService.KiloBits = int.Parse(value);
                BitsInput.Text = _dataCapacityConvertingService.Bits.ToString(CultureInfo.InvariantCulture);
                MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString(CultureInfo.InvariantCulture);
                BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString(CultureInfo.InvariantCulture);
                KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString(CultureInfo.InvariantCulture);
                MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void MegabitsInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = MegabitsInput.Text;
                _dataCapacityConvertingService.MegaBits = int.Parse(value);
                BitsInput.Text = _dataCapacityConvertingService.Bits.ToString(CultureInfo.InvariantCulture);
                KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString(CultureInfo.InvariantCulture);
                BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString(CultureInfo.InvariantCulture);
                KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString(CultureInfo.InvariantCulture);
                MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void BytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = BytesInput.Text;
                _dataCapacityConvertingService.Bytes = int.Parse(value);
                BitsInput.Text = _dataCapacityConvertingService.Bits.ToString(CultureInfo.InvariantCulture);
                KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString(CultureInfo.InvariantCulture);
                MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString(CultureInfo.InvariantCulture);
                KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString(CultureInfo.InvariantCulture);
                MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void KilobytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = KilobytesInput.Text;
                _dataCapacityConvertingService.KiloBytes = int.Parse(value);
                BitsInput.Text = _dataCapacityConvertingService.Bits.ToString(CultureInfo.InvariantCulture);
                KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString(CultureInfo.InvariantCulture);
                MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString(CultureInfo.InvariantCulture);
                BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString(CultureInfo.InvariantCulture);
                MegabytesInput.Text = _dataCapacityConvertingService.MegaBytes.ToString(CultureInfo.InvariantCulture);
            }
        }

        public void MegabytesInput_EnterClicked_Handler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                var value = MegabytesInput.Text;
                _dataCapacityConvertingService.MegaBytes = int.Parse(value);
                BitsInput.Text = _dataCapacityConvertingService.Bits.ToString(CultureInfo.InvariantCulture);
                KilobitsInput.Text = _dataCapacityConvertingService.KiloBits.ToString(CultureInfo.InvariantCulture);
                MegabitsInput.Text = _dataCapacityConvertingService.MegaBits.ToString(CultureInfo.InvariantCulture);
                BytesInput.Text = _dataCapacityConvertingService.Bytes.ToString(CultureInfo.InvariantCulture);
                KilobytesInput.Text = _dataCapacityConvertingService.KiloBytes.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
