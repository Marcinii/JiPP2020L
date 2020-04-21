namespace UnitConverter.Terminal.Style
{
    /// <summary>
    /// Klasa zawierająca zestaw metod do zarządzania zestawem linii do rysowania obramowania tabeli
    /// </summary>
    public class BorderStyleUtils
    {
        /// <summary>
        /// Metoda zwracająca zestaw znaków na podstawie ustawionego stylu
        /// </summary>
        /// <param name="style">Styl obramowania</param>
        /// <returns>Obiekt z zestawem znaków służących do wysowania obramowania tabeli</returns>
        public static BorderLineSet getStyle(BorderStyle style)
        {
            switch (style)
            {
                case BorderStyle.BASIC:
                    return new BorderLineSet()
                    {
                        lineHorizontal = '-',
                        lineVertical = '|',
                        cross = '+',
                        leftEnding = '+',
                        rightEnding = '+',
                        topEnding = '+',
                        bottomEnding = '+',
                        topLeftCorner = '+',
                        topRightCorner = '+',
                        bottomLeftCorner = '+',
                        bottomRightCorner = '+'
                    };

                case BorderStyle.DOUBLE_LINE:
                    return new BorderLineSet()
                    {
                        lineHorizontal = '═',
                        lineVertical = '║',
                        cross = '╬',
                        leftEnding = '╠',
                        rightEnding = '╣',
                        topEnding = '╦',
                        bottomEnding = '╩',
                        topLeftCorner = '╔',
                        topRightCorner = '╗',
                        bottomLeftCorner = '╚',
                        bottomRightCorner = '╝'
                    };
                default: return null;
            }
        }
    }
}
