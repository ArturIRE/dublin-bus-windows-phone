// -----------------------------------------------------------------------
// <copyright file="ISimpleWebClient.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace DublinBusWindowsPhone.Helpers
{
    using System;
    using System.Net;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface ISimpleWebClient
    {
        void UploadStringAsync(Uri address, string data);

        event UploadStringCompletedEventHandler UploadStringCompleted;
    }
}
