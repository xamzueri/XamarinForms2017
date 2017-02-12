using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows.Input;

namespace Task.ViewModels.Helpers
{
    public class Command : ICommand
    {
        Action _execute;
        Func<bool> _canExecute;

        public Command(Action execute) : this(execute, null)
        {
        }

        public Command(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;

            if (canExecute != null)
            {
                _canExecute = canExecute;
            }
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null
                || _canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter) && _execute != null)
            {
                _execute.Invoke();
            }
        }
    }

    
}