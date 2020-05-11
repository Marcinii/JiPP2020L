using System.Windows;
using System.Windows.Controls;
using UnitConverter.Application.AppWindow;
using UnitConverter.Library.RatingUtil;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Application.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction"/>, która reprezentuje nowe zadanie.
    /// Będzie ono wykonywane po właściwym wywołaniu zadania, które wyszujuje ostatnią zapisaną ocenę.
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class FindLastRatingAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                if (runnable.getResult() != null)
                {
                    Rating rating = (Rating)runnable.getResult();
                    Label label = (Label)runnable.getParameter("label").value;

                    label.Content = string.Format("Ostatnia ocena: {0}", rating.value);
                }

                RatingInfoWindow ratingInfoWindow = (RatingInfoWindow)runnable.getParameter("ratingInfoWindow").value;
                ratingInfoWindow.ratingInfoLoadingSpinner.Visibility = Visibility.Hidden;
            });
        }
    }
}
