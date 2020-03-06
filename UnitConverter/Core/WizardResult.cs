using System;
using System.Collections.Generic;
using System.Text;
using UnitConverter.UnitUtil;

namespace UnitConverter.Core
{
    /// <summary>
    /// Klasa, która służy do przechowania danych wpisanych w formularz.
    /// <see cref="ConverterWizard"/>
    /// </summary>
    public class WizardResult
    {
        public double value { get; set; }
        public Unit fromUnit { get; set; }
        public Unit toUnit { get; set; }
    }
}
