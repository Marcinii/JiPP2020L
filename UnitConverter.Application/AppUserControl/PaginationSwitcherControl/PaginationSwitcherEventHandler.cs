namespace UnitConverter.Application.AppUserControl.PaginationSwitcherControl
{
    /// <summary>
    /// Delegat, który ma za zadanie przechwycić wywolane zdarzenie, które będzie wywoływane
    /// w momencie zmiany numeru strony w komponencie <see cref="PaginationSwitcher"/>
    /// </summary>
    /// <param name="sender">Obiekt, w którym wywoływane jest zdarzenie</param>
    /// <param name="args">
    ///     Obiekt, który przechowuje wartości, które zostały zmienione podczas wywoływania zdarzenia
    /// </param>
    /// <see cref="PaginationSwitcherEventArgs"/>
    public delegate void PaginationSwitcherEventHandler(object sender, PaginationSwitcherEventArgs args);
}
