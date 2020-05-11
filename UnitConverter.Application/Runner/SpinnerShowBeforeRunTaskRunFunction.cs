using System.Windows;
using UnitConverter.Application.AppUserControl.LoadingSpinnerControl;
using UnitConverter.Library.TaskUtil;

namespace UnitConverter.Application.Runner
{
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
