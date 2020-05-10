using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Konwerter.Desktop.ViewModel.Commands
{
    public class ConvertCommand : ICommand
    {
        public ViewModelBase viewModel { get; set; }

        public ConvertCommand(ViewModelBase viewModel)
        {
            this.viewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.viewModel.Convert();
        }
    }
}
