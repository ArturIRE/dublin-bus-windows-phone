//-------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Helpers
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;

    /// <summary>
    /// Helper base class for View Models. Adds some useful functions for 
    /// View Model classes
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that indicates one of the ViewModels properties has had it's
        /// value changed. <seealso cref="INotifyPropertyChanged"/>
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = 
            delegate { };

        /// <summary>
        /// Helper method that raises the <see cref="PropertyChanged"/> event
        /// for the supplied property
        /// </summary>
        /// <typeparam name="T">The type of the property</typeparam>
        /// <param name="propertyExpression">
        /// The name of the property that changed as a lambda expression
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0", Justification = "by design")]
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "by design")]
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "by design")]
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "by design")]
        protected void RaisePropertyChanged<T>(
            Expression<Func<T>> propertyExpression)
        {
            Contract.Requires(propertyExpression != null);

// ReSharper disable PossibleNullReferenceException
            var body = (MemberExpression)propertyExpression.Body;
// ReSharper restore PossibleNullReferenceException
            this.PropertyChanged(
                this, 
                new PropertyChangedEventArgs(body.Member.Name));
        }
    }
}
