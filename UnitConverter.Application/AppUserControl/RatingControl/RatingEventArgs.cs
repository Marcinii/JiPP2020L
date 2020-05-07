using System;
using UnitConverter.Library.TypeUtil.Number;

namespace UnitConverter.Application.AppUserControl.RatingControl
{
    /// <summary>
    /// Klasa dziedzicząc klasę <see cref="EventArgs"/>, która będzie wykorzystywana do przekazywania wartości
    /// w trakcie wywoływania zdarzenia zmiany wartości oceny.
    /// </summary>
    /// <param name="value">Wartość oceny</param>
    /// <see cref="CustomInteger"/>
    public class RatingEventArgs : EventArgs
    {
        public CustomInteger value { get; private set; }

        public RatingEventArgs(CustomInteger value)
        {
            this.value = value;
        }
    }
}
