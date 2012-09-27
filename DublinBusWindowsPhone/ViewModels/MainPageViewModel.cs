//-------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBusWindowsPhone.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Windows;
    using DublinBusWindowsPhone.Model;
    using DublinBusWindowsPhone.WebService;
    using Microsoft.Phone.Reactive;

    public class MainPageViewModel : DependencyObject
    {
        private readonly SimpleDelegateCommand searchAndDownloadData;

        public static readonly DependencyProperty ResultsProperty = DependencyProperty.Register("Results", typeof(IEnumerable<BusStopArrivalTime>), typeof(MainPageViewModel), new PropertyMetadata(new List<BusStopArrivalTime>()));

        public static readonly DependencyProperty SearchStringProperty = DependencyProperty.Register("SearchString", typeof(string), typeof(MainPageViewModel), new PropertyMetadata(string.Empty, (s, e) => ((MainPageViewModel)s).SearchAndDownloadData.RaiseCanExecuteChanged()));

        public MainPageViewModel()
        {
            this.searchAndDownloadData = new SimpleDelegateCommand(_ => this.SearchAndDownloadDataExecute(), _ => this.SearchAndDownloadDataCanExecute());
        }

        public string SearchString
        {
            get
            {
                return (string)this.GetValue(SearchStringProperty);
            }

            set
            {
                this.SetValue(SearchStringProperty, value);
            }
        }

        public IEnumerable<BusStopArrivalTime> Results
        {
            get
            {
                return (IEnumerable<BusStopArrivalTime>)this.GetValue(ResultsProperty);
            }

            set
            {
                this.SetValue(ResultsProperty, value);
            }
        }

        public SimpleDelegateCommand SearchAndDownloadData
        {
            get
            {
                return this.searchAndDownloadData;
            }
        }

        private bool SearchAndDownloadDataCanExecute()
        {
            int ignored;

            return int.TryParse(this.SearchString, out ignored);
        }

        private void SearchAndDownloadDataExecute()
        {
            var busStopNumber = int.Parse(this.SearchString);
            var ws = new DublinBusWebServiceClient();

            ws.GetBusStopArrivalTimes(busStopNumber).Subscribe(onNext: (s) => { this.Results = s; });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            Contract.Requires(propertyName != null);

            var handler = this.PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "SearchString")
                {
                    int ignored;

                    if (!int.TryParse(this.SearchString, out ignored))
                    {
                        return "Numeric only! IMPROVE ME";
                    }
                }

                return string.Empty;
            }
        }
    }
}
