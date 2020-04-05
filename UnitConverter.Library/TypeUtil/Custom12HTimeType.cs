using System.ComponentModel;

namespace UnitConverter.Library.TypeUtil
{
    /// <summary>
    /// Enumeracja, która służy do przechowania informacji o porze dnia dla godziny
    /// w formacie 12-godzinnym. Wartość AM - przed południem, PM - po południu
    /// </summary>
    /// <see cref="Custom12HTime"/>
    public enum Custom12HTimeType
    {
        [Description("Przed południem")]
        AM = 0,

        [Description("Po południu")]
        PM = 1
    }
}
