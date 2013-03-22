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
using System.Collections.ObjectModel;

namespace DublinBusWindowsPhone.Designer
{
    public class DesignerFavouriteStopsViewModel : FavouriteStopsViewModel
    {
        public DesignerFavouriteStopsViewModel()
        {
            this.FavouriteStops = new ObservableCollection<string>
            {
                "1337",
                "8008",
                "123"
            };
        }
    }
}
