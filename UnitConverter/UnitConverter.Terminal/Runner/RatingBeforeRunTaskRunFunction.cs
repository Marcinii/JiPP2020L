using System;
using UnitConverter.Library.RatingUtil;
using UnitConverter.Library.TaskUtil;
using UnitConverter.Terminal.RatingUtil;
using UnitConverter.Terminal.RatingUtil.Drawer;

namespace UnitConverter.Terminal.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, reprezentująca nowe zadanie.
    /// Klasa ta jest wywoływana przed uruchomieniem zadania, które będzie zapisywało ocenę aplikacji wskazanej przez użytkownika.
    /// Wyświetla ona widżet, który ma być odpowiednio ustawiony. W zależności od ustawienia tgo widżetu, taka ocena będzie zapisana.
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class RatingBeforeRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            RatingWidget ratingWidget = new RatingWidget();
            RatingWidgetDrawer drawer = new RatingWidgetDrawer(ratingWidget);
            RatingWidgetPresenter presenter = new RatingWidgetPresenter(drawer, ratingWidget);

            drawer.addCustomText(utils =>
            {
                Console.WriteLine("#-----------------------------------------------------------------#");
                if(runnable.getParameter("$prev").value == null)
                {
                    Console.WriteLine("# Aplikacja nie została dotychczas oceniona");
                }
                else
                {
                    Rating rating = (Rating)runnable.getParameter("$prev").value;
                    Console.WriteLine("# Ostatnia ocena: {0}", rating.value);
                }
                Console.WriteLine("#-----------------------------------------------------------------#");
            });

            presenter.presentRating();

            runnable.setParameter("Ocena", ratingWidget.value);
        }
    }
}
