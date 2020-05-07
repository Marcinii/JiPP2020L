using System;
using System.Windows.Input;

namespace UnitConverter.Application.Command
{
    /// <summary>
    /// Klasa implementująca interfejs <see cref="ICommand"/>, która posłuży do tworzenia nowych komend dla przycisków.
    /// </summary>
    /// <see cref="ICommand"/>
    public class ButtonCommand : ICommand
    {
        private Action<object> executable;
        private Predicate<object> executionCondition;
        private event EventHandler _canExecuteChanged;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this._canExecuteChanged += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this._canExecuteChanged -= value;
            }
        }



        public ButtonCommand(Action<object> executable) : this(executable, defaultCondition) { }

        public ButtonCommand(Action<object> executable, Predicate<object> executionCondition)
        {
            this.executable = executable;
            this.executionCondition = executionCondition;
        }




        public bool CanExecute(object parameter) => this.executionCondition != null && this.executionCondition(parameter);

        public void Execute(object parameter) => this.executable(parameter);

        public void OnCanExecuteChanged() => this._canExecuteChanged?.Invoke(this, EventArgs.Empty);

        private static bool defaultCondition(object parameter) => true;
    }
}
