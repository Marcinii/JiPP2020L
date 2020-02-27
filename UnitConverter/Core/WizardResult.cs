using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter.Core
{
    /// <summary>
    /// Klasa, która służy do przechowania danych wpisanych w formularz.
    /// <see cref="ConverterWizard"/>
    /// </summary>
    class WizardResult
    {
        public ConvertTo convertTo { get; private set; }
        public double value { get; set; }


        /// <summary>
        /// Metoda konwertująca wpisaną cyfrę na odpowiednią wartość enumeracji {ConvrtTo}.
        /// Dla wartości option = 1, metoda zwróci wartość {ConvertTo.FIRST}.
        /// Dla wartości option = 2, metoda zwróci wartość {ConvertTo.SECOND}.
        /// </summary>
        /// <param name="option">
        ///     Cyfra do przekonwertowania. Metoda przyjmuje tylko wartości {1} i {2}.
        /// </param>
        /// <see cref="ConvertTo"/>
        public void setOption(int option)
        {
            switch(option)
            {
                case 1: this.convertTo = ConvertTo.FIRST; break;
                case 2: this.convertTo = ConvertTo.SECOND; break;
            }
        }
    }
}
