//-------------------------------------------------------------------------
// <copyright file="DublinBusWebServiceClient.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.Services.Web
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Net;
    using System.Xml.Linq;
    using DublinBusWindowsPhone.Model;
    using DublinBusWindowsPhone.Services.Serializer;
    using Microsoft.Phone.Reactive;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml;
    using Generated;
    using System.ServiceModel.Channels;
    using System.ServiceModel;

    /// <summary>
    /// Web service client for the Dublin bus real time web service
    /// Exposes async methods as observables
    /// </summary>
    public class DublinBusWebServiceClient
    {
        /// <summary>
        /// Makes a request to the Dublin Bus web service for real time
        /// information for a bus stop
        /// </summary>
        /// <param name="busStopNumber">The bus stop's number / id</param>
        /// <returns>
        /// An observable that will contain the result when the web service 
        /// call has ended
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "by design")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "by design")]
        public IObservable<ReadOnlyCollection<BusStopArrivalTime>> GetBusStopArrivalTimes(int busStopNumber)
        {
            var wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "text/xml";

            const string PostEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><GetRealTimeStopData xmlns=\"http://dublinbus.ie/\"><stopId>{0}</stopId><forceRefresh>false</forceRefresh></GetRealTimeStopData></soap:Body></soap:Envelope>";

            var o = Observable
                        .FromEvent<UploadStringCompletedEventArgs>(wc, "UploadStringCompleted")
                        .ObserveOn(Scheduler.NewThread)
                        .Select(r => new Deserializer().DeserializeBusStopArrivalTimes(XDocument.Parse(r.EventArgs.Result)))
                        .ObserveOn(Scheduler.Dispatcher);

            var o2 = Observable.Defer(() => o);

            wc.UploadStringAsync(
                new Uri("http://webservice.dublinbus.biznetservers.com/DublinBusRTPIService.asmx?op=GetRealTimeStopData"),
                string.Format(CultureInfo.InvariantCulture, PostEnvelope, busStopNumber));

            return o2;
        }

        public IObservable<Destination[]> GetAllStops()
        {
            return Observable.Defer(() =>
                {
                    var x = new Generated.DublinBusRTPIServiceSoapClient(new BasicHttpBinding() { MaxBufferSize=2147483647,
                    MaxReceivedMessageSize=2147483647 }, new EndpointAddress(new Uri("http://rtpi.dublinbus.biznetservers.com/DublinBusRTPIService.asmx")));

                    var o = Observable.FromEvent<GetAllDestinationsCompletedEventArgs>(x, "GetAllDestinationsCompleted")
                        .Select(res => res.EventArgs.Result.Destinations);

                    x.GetAllDestinationsAsync();

                    return o;
                });
        }

    }
}
