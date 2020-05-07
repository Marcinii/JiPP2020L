namespace UnitConverter.Application.AppUserControl.RatingControl
{
    /// <summary>
    /// Delegat odpowiedzialny za przechowywanie instancji funkcji, które będą wywoływane 
    /// w momecie, gdy dojdzie do zdarzenia zmiany wartości oceny.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="value"></param>
    /// <see cref="RatingEventArgs"/>
    public delegate void RatingEventHandler(object sender, RatingEventArgs value);
}