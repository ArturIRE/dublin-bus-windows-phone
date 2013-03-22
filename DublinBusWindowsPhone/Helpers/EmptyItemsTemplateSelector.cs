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

namespace DublinBusWindowsPhone.Helpers
{
    public abstract class DataTemplateSelector : ContentControl
    {
        public virtual DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return null;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            ContentTemplate = SelectTemplate(newContent, this);
        }
    }

    //public class EmptyItemsTemplateSelector : DataTemplateSelector
    //{
    //    public override DataTemplate
    //        SelectTemplate(object item, DependencyObject container)
    //    {
    //        FrameworkElement element = container as FrameworkElement;

    //        if (element != null && item != null)
    //        {
    //            Task taskitem = item as Task;

    //            if (taskitem.Priority == 1)
    //                return
    //                    element.FindResource("importantTaskTemplate") as DataTemplate;
    //            else
    //                return
    //                    element.FindResource("myTaskTemplate") as DataTemplate;
    //        }

    //        return null;
    //    }
    //}
}
