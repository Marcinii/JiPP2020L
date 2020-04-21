using System;
using UnitConverter.Terminal.RatingUtil.Drawer;

namespace UnitConverter.Terminal.RatingUtil
{
    /// <summary>
    /// Klasa odpowiedzialna za wyświetlenie widżetu w sposób interaktywny
    /// </summary>
    /// <param name="drawer">Pole, które ma za zadanie nrysowanie widżeu na ekranie</param>
    /// <param name="ratingWidget">Widżet do narysowania</param>
    /// <see cref="RatingWidgetDrawer"/>
    /// <see cref="RatingWidget"/>
    public class RatingWidgetPresenter
    {
        private RatingWidgetDrawer drawer;
        private RatingWidget ratingWidget;

        public RatingWidgetPresenter(RatingWidgetDrawer drawer, RatingWidget ratingWidget)
        {
            this.drawer = drawer;
            this.ratingWidget = ratingWidget;
        }



        /// <summary>
        /// Główna metoda startowa prezentera widżeta.
        /// Reaguje ona na wciśnięte klawisze, dzięki czemu na ich podstawie będzie można wykonać odpowiednie operacje
        /// </summary>
        public void presentRating()
        {
            ConsoleKey key;
            do
            {
                Console.Clear();
                drawer.draw();

                key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        ratingWidget.increaseValue();
                        break;
                    case ConsoleKey.LeftArrow:
                        ratingWidget.decreaseValue();
                        break;
                }
            }
            while (key != ConsoleKey.Enter);
        }
    }
}
