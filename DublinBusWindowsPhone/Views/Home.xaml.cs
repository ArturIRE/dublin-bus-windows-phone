using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace DublinBusWindowsPhone.Views
{
    public partial class Home : PhoneApplicationPage
    {
        public Home()
        {
            InitializeComponent();
        }


        private void GoToTimesPage(object sender, RoutedEventArgs e)
        {
            var url = string.Format("/Views/BusStopTimes.xaml?stopNumber={0}", this.BusStopNumber.Text);
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(new Uri(url, UriKind.Relative));
        }
    }
}