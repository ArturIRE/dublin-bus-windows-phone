

namespace DublinBusWindowsPhone.WebService
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Xml.Linq;
    using DublinBusWindowsPhone.Helpers;
    using DublinBusWindowsPhone.Model;
    using Microsoft.Phone.Reactive;

    public class DublinBusWebServiceClient
    {
        private readonly Func<ISimpleWebClient> simpleWebClientFactory;

        public DublinBusWebServiceClient()
            : this(() => new SimpleWebClient())
        {
        }

        public DublinBusWebServiceClient(Func<ISimpleWebClient> webClientFactory)
        {
            this.simpleWebClientFactory = webClientFactory;
        }

        public IObservable<List<BusStopArrivalTime>> StartBusStopArrivalTimes()
        {
            ISimpleWebClient wc = this.simpleWebClientFactory();

            var o = Observable.FromEvent<UploadStringCompletedEventArgs>(wc, "UploadStringCompleted")
                              .Select(this.Deserialize)
                              .ObserveOn(Scheduler.Dispatcher);

            wc.UploadStringAsync(new Uri("http://www.data.com/service"), string.Empty);

            return o;
        }

        public List<BusStopArrivalTime> Deserialize(IEvent<UploadStringCompletedEventArgs> s)
        {
            var responseData = XDocument.Parse(s.EventArgs.Result);

            return new List<BusStopArrivalTime>();
        }
    }
}
