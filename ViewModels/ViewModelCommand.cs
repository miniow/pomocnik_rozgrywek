using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace Pomocnik_Rozgrywek.ViewModels
{
    public class ViewModelCommand : ICommand
    {
        private readonly Func<object, Task> _executeAsyncAction;
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            _executeAsyncAction = null;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Func<object, Task> executeAsyncAction)
        {
            _executeAsyncAction = executeAsyncAction ?? throw new ArgumentNullException(nameof(executeAsyncAction));
            _executeAction = null;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            _executeAsyncAction = null;
            _canExecuteAction = canExecuteAction;
        }

        public ViewModelCommand(Func<object, Task> executeAsyncAction, Predicate<object> canExecuteAction)
        {
            _executeAsyncAction = executeAsyncAction ?? throw new ArgumentNullException(nameof(executeAsyncAction));
            _executeAction = null;
            _canExecuteAction = canExecuteAction;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteAction == null || _canExecuteAction(parameter);
        }

        public async void Execute(object parameter)
        {
            if (_executeAsyncAction != null)
            {
                await _executeAsyncAction(parameter);
            }
            else
            {
                _executeAction(parameter);
            }
        }

        public void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
    }
}
