//-------------------------------------------------------------------------
// <copyright file="MainPageViewModel.cs" company="Artur Philibin E Silva">
//     Copyright (c) Artur Philibin E Silva All rights reserved.
// </copyright>
//-------------------------------------------------------------------------

namespace DublinBus.Net
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Net;
    using System.Windows;
    using C = System.Diagnostics.Contracts.Contract;

    public class MainPageViewModel : DependencyObject
    {
        private readonly SimpleDelegateCommand searchAndDownloadData;

        public static readonly DependencyProperty ResultsProperty = DependencyProperty.Register("Results", typeof(string), typeof(MainPageViewModel), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SearchStringProperty = DependencyProperty.Register("SearchString", typeof(string), typeof(MainPageViewModel), new PropertyMetadata(string.Empty, (s, e) => ((MainPageViewModel)s).SearchAndDownloadData.RaiseCanExecuteChanged()));

        public MainPageViewModel()
        {
            this.searchAndDownloadData = new SimpleDelegateCommand(_ => SearchAndDownloadDataExecute(), _ => this.SearchAndDownloadDataCanExecute());
        }

        public string SearchString
        {
            get
            {
                return (string)GetValue(SearchStringProperty);
            }

            set
            {
                SetValue(SearchStringProperty, value);
            }
        }

        public string Results
        {
            get
            {
                return (string)GetValue(ResultsProperty);
            }

            set
            {
                SetValue(ResultsProperty, value);
            }
        }

        public SimpleDelegateCommand SearchAndDownloadData
        {
            get
            {
                return searchAndDownloadData;
            }
        }

        private bool SearchAndDownloadDataCanExecute()
        {
            int ignored;

            return int.TryParse(this.SearchString, out ignored);
        }

        private void SearchAndDownloadDataExecute()
        {
            var busStopNumber = int.Parse(this.SearchString).ToString(NumberFormatInfo.InvariantInfo).PadLeft(5, '0');
            var wc = new WebClient();
            wc.DownloadStringCompleted += DownloadStringCompleted;
            wc.DownloadStringAsync(new Uri("http://gormcito.com/api.php?n=" + busStopNumber));
        }

        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.Results = string.Concat(Helpers.ExtractBusTimesFromHtml(e.Result));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            C.Requires(propertyName != null);

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
