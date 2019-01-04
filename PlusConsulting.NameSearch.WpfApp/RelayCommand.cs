using System;
using System.Windows.Input;

namespace PlusConsulting.NameSearch.WpfApp
{
    // https://stackoverflow.com/a/1468830/1202501
    // Many similar implementations of this can be found on the internet but I'd normally 
    // go with an MVVM framework that abstracts away the details for me so I can focus on the app itself.
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}
