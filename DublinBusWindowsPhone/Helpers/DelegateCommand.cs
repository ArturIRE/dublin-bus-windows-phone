//-------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Helpers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Windows.Input;

    /// <summary>
    /// This object removes the need to declare a new Command class for each
    /// Command in the application, and instead lets Command objects be created
    /// by specifying their <see cref="Execute"/> and <see cref="CanExecute"/>
    /// methods with delegates
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// A stored copy of the delegate used for the <see cref="Execute"/>
        /// method
        /// </summary>
        private readonly Action<object> executeAction;

        /// <summary>
        /// A stored copy of the delegate used for the <see cref="CanExecute"/>
        /// method
        /// </summary>
        private readonly Func<object, bool> canExecuteFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/>
        /// class
        /// </summary>
        /// <param name="execute">
        /// A delegate specifying the behaviour of the <see cref="Execute"/>
        /// method
        /// </param>
        /// <param name="canExecute">
        /// A delegate specifying the behaviour of the <see cref="CanExecute"/>
        /// method
        /// </param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            Contract.Requires(execute != null);
            Contract.Requires(canExecute != null);

            this.executeAction = execute;
            this.canExecuteFunc = canExecute;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/>
        /// class
        /// </summary>
        /// <param name="execute">
        /// A delegate specifying the behaviour of the <see cref="Execute"/>
        /// method
        /// </param>
        public DelegateCommand(Action<object> execute)
        {
            Contract.Requires(execute != null);

            this.executeAction = execute;
            this.canExecuteFunc = _ => true;
        }

        /// <summary>
        /// Event raised when the result of <see cref="CanExecute"/> has 
        /// possibly changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// This method evaluates whether or not the Command can be executed
        /// </summary>
        /// <param name="parameter">
        /// A parameter supplied to the corresponding delegate
        /// </param>
        /// <returns>
        /// True if the command can be executed, false otherwise
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecuteFunc(parameter);
        }

        /// <summary>
        /// The actual logic behind the Command
        /// </summary>
        /// <param name="parameter">
        /// A parameter supplied to the corresponding delegate
        /// </param>
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "by design")]
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
