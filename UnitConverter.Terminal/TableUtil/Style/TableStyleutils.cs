namespace UnitConverter.Terminal.TableUtil.Style
{
    /// <summary>
    /// Klasa zawierająca zestaw metod do zarządzania zestawem linii do rysowania obramowania tabeli
    /// </summary>
    public class TableStyleUtils
    {
        /// <summary>
        /// Metoda zwracająca zestaw znaków na podstawie ustawionego stylu
        /// </summary>
        /// <param name="style">Styl obramowania</param>
        /// <returns>Obiekt z zestawem znaków służących do wysowania obramowania tabeli</returns>
        public static TableLineSet getStyle(TableStyle style)
        {
            switch (style)
            {
                case TableStyle.BASIC:
                    return new TableLineSet()
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

                case TableStyle.DOUBLE_LINE:
                    return new TableLineSet()
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
