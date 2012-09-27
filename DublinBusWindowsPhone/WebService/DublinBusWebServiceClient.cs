//-------------------------------------------------------------------------
// <copyright file="DublinBusWebServiceClient.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.WebService
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Xml.Linq;
    using DublinBusWindowsPhone.Model;
    using Microsoft.Phone.Reactive;

    public class DublinBusWebServiceClient
    {
        public IObservable<List<BusStopArrivalTime>> GetBusStopArrivalTimes(int busStopNumber)
        {
            var wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "text/xml";

            var postEnvelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?><soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body><GetRealTimeStopData xmlns=\"http://dublinbus.ie/\"><stopId>{0}</stopId><forceRefresh>false</forceRefresh></GetRealTimeStopData></soap:Body></soap:Envelope>";

            var o = Observable
                        .FromEvent<UploadStringCompletedEventArgs>(wc, "UploadStringCompleted")
                        .ObserveOn(Scheduler.NewThread)
                        .Select(this.Deserialize)
                        .ObserveOn(Scheduler.Dispatcher);

            var o2 = Observable.Defer(() => o);

            wc.UploadStringAsync(
                new Uri("http://webservice.dublinbus.biznetservers.com/DublinBusRTPIService.asmx?op=GetRealTimeStopData"),
                string.Format(postEnvelope, busStopNumber));

            return o2;
        }

        private List<BusStopArrivalTime> Deserialize(IEvent<UploadStringCompletedEventArgs> s)
        {
            var responseData = XDocument.Parse(s.EventArgs.Result);

            var list = new List<BusStopArrivalTime>();

            foreach (var xmlBusStopArrivaltime in responseData.Descendants("StopData"))
            {
                var expectedArrivalTime =
                    DateTime.Parse(xmlBusStopArrivaltime.Element("MonitoredCall_ExpectedArrivalTime").Value);
                var currentServerTime =
                    DateTime.Parse(xmlBusStopArrivaltime.Element("StopMonitoringDelivery_ResponseTimestamp").Value);

                var minutesUntilArrival = Convert.ToInt32(expectedArrivalTime.Subtract(currentServerTime).TotalMinutes);

                list.Add(new BusStopArrivalTime(
                    xmlBusStopArrivaltime.Element("MonitoredVehicleJourney_PublishedLineName").Value,
                    xmlBusStopArrivaltime.Element("MonitoredVehicleJourney_DestinationName").Value,
                    minutesUntilArrival));
            }



            return list;
        }
    }
}
