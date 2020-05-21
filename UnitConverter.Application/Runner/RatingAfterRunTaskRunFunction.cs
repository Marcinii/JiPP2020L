using System.Windows;
using UnitConverter.Application.AppWindow;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Application.Runner
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="TaskRunFunction" />
    /// Ma ona za zadanie przechowywać definicję funkcji, która bedzie wykonywana po
    /// wykonaniu zadania, które zapisuje zaznaczoną przez użytkownika ocenę. 
    /// Będzie wyświetlał okienko z podziękowaniem za ocenę aplikacji.
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class RatingAfterRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                RatingInfoWindow ratingInfoWindow = (RatingInfoWindow)runnable.getParameter("ratingInfoWindow").value;
                ratingInfoWindow.ratingInfoLoadingSpinner.Visibility = Visibility.Hidden;

                MessageBox.Show(
                    ratingInfoWindow,
                    "Dziękuję za ocenienie aplikacji",
                    "Konwerter jednostek",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );

                ratingInfoWindow.Close();
            });
        }
    }
}
