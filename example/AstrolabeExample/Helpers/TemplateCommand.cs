using System;
using System.Windows.Input;

namespace AstrolabeExample.Helpers
{
    public class TemplateCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public TemplateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        ///<inheritdoc />
        public bool CanExecute(object parameter) =>
            canExecute?.Invoke(parameter) ?? true;

        ///<inheritdoc />
        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                return;
            }

            execute?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}