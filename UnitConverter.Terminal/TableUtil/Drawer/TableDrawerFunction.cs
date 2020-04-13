namespace UnitConverter.Terminal.TableUtil.Drawer
{
    /// <summary>
    /// Delegat, który będzie wykorzystywany do przechowania instrukcji 
    /// służacych do wyświetlenia tekstu w tabeli
    /// </summary>
    /// <param name="utils">
    ///     Pole przechowujące zestaw metod do rysowania tabeli
    /// </param>
    public delegate void TableDrawerFunction(TableDrawerUtils utils);
}
