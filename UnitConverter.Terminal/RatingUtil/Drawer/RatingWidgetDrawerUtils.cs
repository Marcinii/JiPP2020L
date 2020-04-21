using System;
using UnitConverter.Terminal.Style;

namespace UnitConverter.Terminal.RatingUtil.Drawer
{
    /// <summary>
    /// Klasa posiadająca zestaw metod, które będą potrzebne do narysowania widżetu oceniającego
    /// </summary>
    /// <param name="ratingWidget">Widżet do narysowania</param>
    /// <param name="borderLineSet">Zestaw znaków potrzebnych do narysowania obramowania widżetu</param>
    /// <see cref="RatingWidget"/>
    /// <see cref="BorderLineSet"/>
    public class RatingWidgetDrawerUtils
    {
        private RatingWidget ratingWidget;
        private BorderLineSet borderLineSet;



        public RatingWidgetDrawerUtils(RatingWidget ratingWidget)
        {
            this.ratingWidget = ratingWidget;
            this.borderLineSet = BorderStyleUtils.getStyle(ratingWidget.borderStyle);
        }




        /// <summary>
        /// Metoda rysuje linię poziomą startową (linię, która rozpoczyna rysowanie widżetuu)
        /// </summary>
        public void drawStartingRule() => drawRule(borderLineSet.topLeftCorner, borderLineSet.topRightCorner, borderLineSet.lineHorizontal, borderLineSet.topEnding);



        /// <summary>
        /// Metoda rysująca linię rozdzielającą główną cześć widżetu od stopki (części, w której będzie wypisany tekst)
        /// </summary>
        public void drawSplitterRule() => drawRule(borderLineSet.leftEnding, borderLineSet.rightEnding, borderLineSet.lineHorizontal, borderLineSet.bottomEnding);



        /// <summary>
        /// Metoda rysuje linię poziomą kończącą (linię, która kończy rysowanie widżetuu)
        /// </summary>
        /// <param name="cross"></param>
        public void drawEndingRule(bool cross = false) => drawRule(borderLineSet.bottomLeftCorner, borderLineSet.bottomRightCorner, borderLineSet.lineHorizontal, cross ? borderLineSet.bottomEnding : borderLineSet.lineHorizontal);



        /// <summary>
        /// Metoda, która ma za zadanie narysowanie gwiazdek w widżecie. Ilość gwiazdek będzie zależała
        /// od ustawionej wartości widżetu
        /// </summary>
        public void drawStars()
        {
            for (int i = 0; i < ratingWidget.padding; i++)
                drawRule(borderLineSet.lineVertical, borderLineSet.lineVertical, ' ', borderLineSet.lineVertical);

            for (int i = 0; i < ratingWidget.maxValue; i++)
            {
                Console.Write(borderLineSet.lineVertical);

                for (int j = 0; j < ratingWidget.padding; j++)
                    Console.Write(' ');

                Console.Write((ratingWidget.value >= i + 1) ? '*' : ' ');

                for (int j = 0; j < ratingWidget.padding; j++)
                    Console.Write(' ');
            }
            Console.WriteLine(borderLineSet.lineVertical);

            for (int i = 0; i < ratingWidget.padding; i++)
                drawRule(borderLineSet.lineVertical, borderLineSet.lineVertical, ' ', borderLineSet.lineVertical);
        }



        /// <summary>
        /// Metoda ma za zadanie narysowanie linii poziomej
        /// </summary>
        /// <param name="beginChar">Znak początkowy</param>
        /// <param name="endChar">Znak końcowy</param>
        /// <param name="verticalLineChar">
        ///     Znak poziomy, który jest wyświetlany do wypełnienia przestrzeni między znakiem początkowym, znakiem końcowym oraz znakiem przecięcia linii
        /// </param>
        /// <param name="crossChar">Znak, kóry wyświetlany jest w miejscu przecięcia dwóch linii</param>
        private void drawRule(char beginChar, char endChar, char lineChar, char crossChar)
        {
            Console.Write(beginChar);

            for (int i = 0; i < ratingWidget.maxValue; i++)
            {
                for (int j = 0; j < 2 * ratingWidget.padding + 1; j++)
                    Console.Write(lineChar);

                if (i < ratingWidget.maxValue - 1)
                    Console.Write(crossChar);
            }
            Console.WriteLine(endChar);
        }
    }
}
