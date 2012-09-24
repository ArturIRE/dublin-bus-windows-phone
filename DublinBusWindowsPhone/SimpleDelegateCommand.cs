//-------------------------------------------------------------------------
// <copyright file="SimpleDelegateCommand.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    public class SimpleDelegateCommand : ICommand
    {
        private readonly Action<object> executeAction;

        private readonly Func<object, bool> canExecuteFunc;

        public SimpleDelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            Contract.Requires(execute != null);
            Contract.Requires(canExecute != null);

            this.executeAction = execute;
            this.canExecuteFunc = canExecute;
        }

        public SimpleDelegateCommand(Action<object> execute)
        {
            Contract.Requires(execute != null);

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
