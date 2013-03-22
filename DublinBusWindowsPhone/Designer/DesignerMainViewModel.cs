//-------------------------------------------------------------------------
// <copyright file="DesignerMainViewModel.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone
{
    using System.Collections.Generic;
    using DublinBusWindowsPhone.Model;
    using DublinBusWindowsPhone.ViewModels;

    /// <summary>
    /// Designer version of the 
    /// <see cref="BusStopRealTimeInformationViewModel"/>, exposes example data
    /// to help designing views in Design mode
    /// </summary>
    public class DesignerMainViewModel : BusStopRealTimeInformationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DesignerMainViewModel"/> class
        /// </summary>
        public DesignerMainViewModel()
        {
            this.BusStopArrivalTimes = new List<BusStopArrivalTime>
            {
                new BusStopArrivalTime("123", "City center", 0),
                new BusStopArrivalTime(
                    "5", "Liffey Valley Shopping Centre", 7),
                new BusStopArrivalTime("19a", "Place", 17),
                new BusStopArrivalTime(
                    "747b", "Soem place - some other place", 103),
            };

            this.BusStopNumber = "1377";
        }
    }
}
