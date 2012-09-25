namespace DublinBusWindowsPhone.Helpers
{
    using System;
    using System.Net;

    public class SimpleWebClient : ISimpleWebClient
    {
        private readonly WebClient webClient;

        public SimpleWebClient()
        {
            this.webClient = new WebClient();
        }

        public void UploadStringAsync(Uri address, string data)
        {
            this.webClient.UploadStringAsync(address, data);
        }

        public event UploadStringCompletedEventHandler UploadStringCompleted
        {
            add
            {
                this.webClient.UploadStringCompleted += value;
            }

            remove
            {
                this.webClient.UploadStringCompleted -= value;
            }
        }
    }
}
