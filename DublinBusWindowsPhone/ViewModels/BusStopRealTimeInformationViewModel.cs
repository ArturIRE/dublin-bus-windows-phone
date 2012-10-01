//-------------------------------------------------------------------------
// <copyright file="BusStopRealTimeInformationViewModel.cs">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.ViewModels
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using DublinBusWindowsPhone.Helpers;
    using DublinBusWindowsPhone.Model;
    using DublinBusWindowsPhone.Services.Web;
    using DublinBusWindowsPhone.Views;
    using Microsoft.Phone.Reactive;

    /// <summary>
    /// ViewModel for the <see cref="BusStopRealTimeInformationView"/> view.
    /// This view displays a list of <see cref="BusStopArrivalTime"/>s for a 
    /// requested stop.
    /// </summary>
    public class BusStopRealTimeInformationViewModel : ViewModelBase
    {
        /// <summary>
        /// Command object that executes a web request to retrieve real time
        /// bus stop information for a specific bus stop number
        /// </summary>
        private readonly DelegateCommand searchForRealTimeData;

        /// <summary>
        /// Backing <see cref="DependencyProperty"/> for "BusStopArrivalTimes"
        /// </summary>
        private IEnumerable<BusStopArrivalTime> busStopArrivalTimes = 
            Enumerable.Empty<BusStopArrivalTime>();

        /// <summary>
        /// Backing field for <see cref="BusStopNumber"/>
        /// </summary>
        private string busStopNumber = string.Empty;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="BusStopRealTimeInformationViewModel"/> class
        /// </summary>
        public BusStopRealTimeInformationViewModel()
        {
            this.searchForRealTimeData = 
                new DelegateCommand(
                    _ => this.SearchAndDownloadDataExecute(), 
                    _ => this.SearchAndDownloadDataCanExecute());
        }

        /// <summary>
        /// Gets or sets the bus stop number to use to search for real time
        /// data
        /// </summary>
        public string BusStopNumber
        {
            get
            {
                return this.busStopNumber;
            }

            set
            {
                if (value != this.busStopNumber)
                {
                    this.busStopNumber = value;
                    this.RaisePropertyChanged(() => this.BusStopNumber);
                    this.searchForRealTimeData.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets a list of <see cref="BusStopArrivalTime"/>s for the 
        /// searched
        /// <see cref="BusStopNumber"/>
        /// </summary>
        public IEnumerable<BusStopArrivalTime> BusStopArrivalTimes
        {
            get
            {
                return this.busStopArrivalTimes;
            }

            protected set
            {
                if (value != this.busStopArrivalTimes)
                {
                    this.busStopArrivalTimes = value;
                    this.RaisePropertyChanged(() => this.BusStopArrivalTimes);
                }
            }
        }

        /// <summary>
        /// Gets the command that executes a search for real time information
        /// for the bus stop specified in <see cref="BusStopNumber"/> and
        /// populates <see cref="BusStopArrivalTimes"/> with the results
        /// </summary>
        public ICommand SearchForRealTimeData
        {
            get
            {
                return this.searchForRealTimeData;
            }
        }

        /// <summary>
        /// The effective CanExecute method for the 
        /// <see cref="SearchForRealTimeData"/> command
        /// </summary>
        /// <returns>True if execution is allowed</returns>
        private bool SearchAndDownloadDataCanExecute()
        {
            int ignored;

            return int.TryParse(this.BusStopNumber, out ignored);
        }

        /// <summary>
        /// The effective Execute() method for the 
        /// <see cref="SearchForRealTimeData"/> command
        /// </summary>
        private void SearchAndDownloadDataExecute()
        {
            var ws = new DublinBusWebServiceClient();

            ws.GetBusStopArrivalTimes(int.Parse(this.busStopNumber, CultureInfo.CurrentCulture))
              .Subscribe(s => { this.BusStopArrivalTimes = s; });
        }
    }
}
