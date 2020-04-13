namespace UnitConverter.Terminal.TableUtil.Cell
{
    /// <summary>
    /// Enumeracja określająca położenie tekstu w komórce tabeli
    /// </summary>
    public enum TableCellAlign
    {
        /// <summary>
        /// Położenie domyślne (ustalane dla danego typu danych)
        /// </summary>
        DEFAULT,
        
        /// <summary>
        /// Tekst będzie wyrównywany do lewej strony
        /// </summary>
        LEFT,

        /// <summary>
        /// Tekst będzie wyrównywany do prawej strony
        /// </summary>
        RIGHT,
        
        /// <summary>
        /// Tekst będzie wyśrodkowany
        /// </summary>
        CENTER
    }
}
