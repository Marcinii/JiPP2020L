namespace UnitConverter.Terminal.TableUtil.Style
{
    /// <summary>
    /// Klasa przechowująca zestaw znaków, które posłużą do narysowania obramowania tabeli
    /// </summary>
    /// <param name="lineHorizontal">Znak lini pionowej</param>
    /// <param name="lineVertical">Znak linii pionowej</param>
    /// <param name="cross">Znak przecięcia linii</param>
    /// <param name="leftEnding">Znak rozpoczęcia poziomej linii</param>
    /// <param name="rightEnding">Znak zakończenia poinowej linii</param>
    /// <param name="topEnding">Znak rozpoczęcia pionowej linii</param>
    /// <param name="bottomEnding">Znak zakończenia pionowej linii</param>
    /// <param name="topLeftCorner">Znak lewego górnego rogu tabeli</param>
    /// <param name="topRightCorner">Znak prawego górnego rogu tabeli</param>
    /// <param name="bottomLeftCorner">Znak lewego dolnego rogu tabeli</param>
    /// <param name="bottomRightCorner">Znak prawego dolnego rogu tabeli</param>
    public class TableLineSet
    {
        public char lineHorizontal { get; set; }
        public char lineVertical { get; set; }
        public char cross { get; set; }
        public char leftEnding { get; set; }
        public char rightEnding { get; set; }
        public char topEnding { get; set; }
        public char bottomEnding { get; set; }
        public char topLeftCorner { get; set; }
        public char topRightCorner { get; set; }
        public char bottomLeftCorner { get; set; }
        public char bottomRightCorner { get; set; }
    }
}
