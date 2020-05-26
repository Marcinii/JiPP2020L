using System;

namespace UnitConverter.Terminal.RatingUtil.Drawer
{
    /// <summary>
    /// Klasa, która ma za zadanie narysować widżet do oceniania
    /// </summary>
    /// <param name="ratingWidget">Widżet do narysowania</param>
    /// <param name="ratingWidgetDrawerUtils">
    ///     Pole zawierające zestaw metod potrzebnych do rysowania widżetu
    /// </param>
    /// <param name="ratingWidgetDrawerFunction">
    ///     Pole przechowujące zestaw metod, które posłużą do wypisania tekstu pod widżetem
    /// </param>
    public class RatingWidgetDrawer
    {
        private RatingWidget ratingWidget;
        private RatingWidgetDrawerUtils ratingWidgetDrawerUtils;
        private RatingWidgetDrawerFunction ratingWidgetDrawerFunction;


        public RatingWidgetDrawer(RatingWidget ratingWidget)
        {
            this.ratingWidget = ratingWidget;
            this.ratingWidgetDrawerUtils = new RatingWidgetDrawerUtils(ratingWidget);
        }


        
        /// <summary>
        /// Metoda, która dodaje nową funkcję do delegatu. Każda z funkcji ma za zadanie wypisać tekst
        /// pod widżetem
        /// </summary>
        /// <param name="ratingWidgetDrawerFunction">
        ///     Wskaźnik do funkcji wypisującej tekst
        /// </param>
        /// <see cref="RatingWidgetDrawerFunction"/>
        public void addCustomText(RatingWidgetDrawerFunction ratingWidgetDrawerFunction)
        {
            this.ratingWidgetDrawerFunction += ratingWidgetDrawerFunction;
        } 



        /// <summary>
        /// Metoda rysująca widzet w konsoli
        /// </summary>
        public void draw()
        {
            this.ratingWidgetDrawerUtils.drawStartingRule();
            this.ratingWidgetDrawerUtils.drawStars();
            this.ratingWidgetDrawerUtils.drawEndingRule(true);
            Console.WriteLine();

            Console.WriteLine("#-----------------------------------------------------------------#");
            if (this.ratingWidget.value > 1)
                Console.WriteLine("# Wciśnij strzałkę w lewo, by zmniejszyć wartość");

            if (this.ratingWidget.value < this.ratingWidget.maxValue)
                Console.WriteLine("# Wciśnij strzałkę w prawo, by zmniejszyć wartość");

            Console.WriteLine("# Wciśnij Enter, aby zatwierdzić wybór");

            this.ratingWidgetDrawerFunction?.Invoke(this.ratingWidgetDrawerUtils);
        }
    }
}
