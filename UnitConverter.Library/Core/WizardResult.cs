using UnitConverter.Library.UnitUtil;

namespace UnitConverter.Library.Core
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
