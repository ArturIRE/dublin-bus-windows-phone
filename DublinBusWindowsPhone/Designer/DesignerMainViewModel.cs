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
using DublinBusWindowsPhone.ViewModels;

namespace DublinBusWindowsPhone.Designer
{
    using System.Collections.Generic;
    using DublinBusWindowsPhone.Model;

    public class DesignerMainViewModel : MainPageViewModel
    {
        public DesignerMainViewModel()
        {
            var exmapleBusStopArrivalTimes = new List<BusStopArrivalTime>
            {
                new BusStopArrivalTime("123", "City center", 0),
                new BusStopArrivalTime("5", "Liffey Valley Shopping Centre", 7),
                new BusStopArrivalTime("19a", "Place", 17),
                new BusStopArrivalTime("747b", "Soem place - some other place", 103),
            };

            this.SetValue(MainPageViewModel.ResultsProperty, exmapleBusStopArrivalTimes);

            var exampleBusStopNumber = "98765";

            this.SetValue(MainPageViewModel.SearchStringProperty, exampleBusStopNumber);
        }
    }
}
