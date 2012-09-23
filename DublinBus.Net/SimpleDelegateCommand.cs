using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DublinBus.Net
{
    public class SimpleDelegateCommand : ICommand
    {
        private readonly Action<object> executeAction;

        private readonly Func<object, bool> canExecuteFunc;

        public SimpleDelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            execute.ThrowIfNull("execute");
            canExecute.ThrowIfNull("canExecute");

            this.executeAction = execute;
            this.canExecuteFunc = canExecute;
        }

        public SimpleDelegateCommand(Action<object> execute)
        {
            execute.ThrowIfNull("execute");

            this.executeAction = execute;
            this.canExecuteFunc = _ => true;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecuteFunc(parameter);
        }

        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
