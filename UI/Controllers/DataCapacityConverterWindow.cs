using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using Logic.Services;
using Logic.Services.Interfaces;

namespace UI.Controllers
{
    public class DataCapacityConverterWindow : MainWindow
    {
        private readonly IDataCapacityConvertingService converter;
        public void FillAllInputs()
        {
            this.BitsInput.Text = converter.Bits.ToString(CultureInfo.InvariantCulture);
            this.KilobitsInput.Text = converter.KiloBits.ToString(CultureInfo.InvariantCulture);
            this.MegabitsInput.Text = converter.MegaBits.ToString(CultureInfo.InvariantCulture);
            this.BytesInput.Text = converter.Bytes.ToString(CultureInfo.InvariantCulture);
            this.KilobytesInput.Text = converter.KiloBytes.ToString(CultureInfo.InvariantCulture);
            this.MegabytesInput.Text = converter.MegaBytes.ToString(CultureInfo.InvariantCulture);
        }
    }
}
