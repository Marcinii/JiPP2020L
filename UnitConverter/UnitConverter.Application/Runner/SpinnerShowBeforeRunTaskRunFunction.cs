using System.Windows;
using UnitConverter.Application.AppUserControl.LoadingSpinnerControl;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Application.Runner
{
    /// <summary>
    /// Klasa implemmentująca interfejs <see cref="TaskRunFunction" />.
    /// Reprezentuje ona funkcję, która będzie wywoływana przez wykonywaniem właściwych zadań.
    /// Ma ona za zadanie wyświetlić nakładkę na aplikację, która poinformuje użytkownika,
    /// że aplikkacja jest w tej chwili ładowana
    /// </summary>
    /// <see cref="TaskRunFunction"/>
    public class SpinnerShowBeforeRunTaskRunFunction : TaskRunFunction
    {
        public void apply(IRunnable runnable)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(() =>
            {
                LoadingSpinner loadingSpinner = (LoadingSpinner)runnable.getParameter("spinner").value;
                loadingSpinner.Visibility = Visibility.Visible;
            });
        }
    }
}
