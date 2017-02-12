using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Windows.Input;

namespace Task.ViewModels.Helpers
{

    public class GenericCommand<T> : ICommand
    {
        Action<T> _execute;
        Func<T, bool> _canExecute;

        public GenericCommand(Action<T> execute) : this(execute, null)
        {
        }

        public GenericCommand(Action<T> execute, Func<T, bool> canExecute)
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
            if (_canExecute == null)
            {
                return true;
            }

            if (parameter == null && typeof(T).GetTypeInfo().IsValueType)
            {
                return _canExecute.Invoke(default(T));
            }

            if (parameter == null || parameter is T)
            {
                return (_canExecute.Invoke((T)parameter));
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var val = parameter;

            if (CanExecute(val) && _execute != null)
            {
                if (val == null)
                {
                    if (typeof(T).GetTypeInfo().IsValueType)
                    {
                        _execute.Invoke(default(T));
                    }
                    else
                    {
                        // ReSharper disable ExpressionIsAlwaysNull
                        _execute.Invoke((T)val);
                        // ReSharper restore ExpressionIsAlwaysNull
                    }
                }
                else
                {
                    _execute.Invoke((T)val);
                }
            }
        }
    }
}